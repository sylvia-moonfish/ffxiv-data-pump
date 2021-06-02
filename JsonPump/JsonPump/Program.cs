using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JsonPump._5._3;
using JsonPump.Models;
using JsonPump.SquareEnix;
using JsonPump.SquareEnix.ExFiles;

namespace JsonPump
{
    public class Program
    {
        // Game client installation path. Change as necessary.
        public static string GlobalClientPath =
            @"C:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn\game\sqpack\ffxiv";

        public static string KoreanClientPath = @"D:\Program Files (x86)\FINAL FANTASY XIV - KOREA\game\sqpack\ffxiv";

        public static string ImageBasePath = @"C:\Users\serap\Documents\GitHub\fishbowl-dev\public";
        public static string OutputBasePath = @"C:\Users\serap\Documents\GitHub\fishbowl-dev\public\data\bis-guide";

        // Some dictionaries for linking.
        public static Dictionary<int, BaseParam> BaseParams = new();
        public static Dictionary<int, ClassJobCategory> ClassJobCategories = new();
        public static Dictionary<int, EquipSlotCategory> EquipSlotCategories = new();
        public static Dictionary<int, ItemUICategory> ItemUICategories = new();
        public static Dictionary<int, ItemFood> ItemFoods = new();
        public static Dictionary<int, ItemAction> ItemActions = new();
        public static Dictionary<int, Materia> Materias = new();

        public static Dictionary<int, MateriaItem> MateriaItems = new();
        public static Dictionary<string, int> MateriaItemCodeMapper = new();

        public static Dictionary<int, Meal> Meals = new();
        public static Dictionary<string, int> MealNameMapper = new();

        public static Dictionary<int, Equipment> Equipments = new();
        public static Dictionary<string, int> EquipmentNameMapper = new();

        private static void Main()
        {
            // Read and cache global client data.
            var sqCache = new SqCache(GlobalClientPath, "0a0000.win32.index", "0a0000.win32.dat0");

            // Process BaseParam into memory.
            Console.WriteLine("[BaseParam] Processing...");
            var baseParamExH = new ExHFile(sqCache.GetFile("exd", "BaseParam.exh"));
            baseParamExH.Iterate(sqCache, "exd", "BaseParam_{0}_en.exd",
                exDFile => { exDFile.Iterate(row => { BaseParams.Add(row.Key, new BaseParam(row)); }); });

            // Process ClassJobCategory into memory.
            Console.WriteLine("[ClassJobCategory] Processing...");
            var classJobCategoryExH = new ExHFile(sqCache.GetFile("exd", "ClassJobCategory.exh"));
            classJobCategoryExH.Iterate(sqCache, "exd", "ClassJobCategory_{0}_en.exd",
                exDFile =>
                {
                    exDFile.Iterate(row => { ClassJobCategories.Add(row.Key, new ClassJobCategory(row)); });
                });

            // Process EquipSlotCategory into memory.
            Console.WriteLine("[EquipSlotCategory] Processing...");
            var equipSlotCategoryExH = new ExHFile(sqCache.GetFile("exd", "EquipSlotCategory.exh"));
            equipSlotCategoryExH.Iterate(sqCache, "exd", "EquipSlotCategory_{0}.exd",
                exDFile =>
                {
                    exDFile.Iterate(row => { EquipSlotCategories.Add(row.Key, new EquipSlotCategory(row)); });
                });

            // Process ItemUICategory into memory.
            Console.WriteLine("[ItemUICategory] Processing...");
            var itemUICategoryExH = new ExHFile(sqCache.GetFile("exd", "ItemUICategory.exh"));
            itemUICategoryExH.Iterate(sqCache, "exd", "ItemUICategory_{0}_en.exd",
                exDFile => { exDFile.Iterate(row => { ItemUICategories.Add(row.Key, new ItemUICategory(row)); }); });

            // Process ItemFood into memory.
            Console.WriteLine("[ItemFood] Processing...");
            var itemFoodExH = new ExHFile(sqCache.GetFile("exd", "ItemFood.exh"));
            itemFoodExH.Iterate(sqCache, "exd", "ItemFood_{0}.exd", exDFile =>
            {
                exDFile.Iterate(row =>
                {
                    var itemFood = new ItemFood(row);

                    if (itemFood.Values.Count > 0) ItemFoods.Add(row.Key, itemFood);
                });
            });

            // Process ItemAction into memory.
            Console.WriteLine("[ItemAction] Processing...");
            var itemActionExH = new ExHFile(sqCache.GetFile("exd", "ItemAction.exh"));
            itemActionExH.Iterate(sqCache, "exd", "ItemAction_{0}.exd", exDFile =>
            {
                exDFile.Iterate(row =>
                {
                    var itemAction = new ItemAction(row);

                    if (ItemFoods.ContainsKey(itemAction.ItemFoodKey)) ItemActions.Add(row.Key, itemAction);
                });
            });

            // Process Materia into memory.
            Console.WriteLine("[Materia] Processing...");
            var materiaExH = new ExHFile(sqCache.GetFile("exd", "Materia.exh"));
            materiaExH.Iterate(sqCache, "exd", "Materia_{0}.exd", exDFile =>
            {
                exDFile.Iterate(row =>
                {
                    var materias = MateriaFactory.CreateMateriasFromRow(row);

                    foreach (var materia in materias)
                        if (!Materias.ContainsKey(materia.ItemKey))
                            Materias.Add(materia.ItemKey, materia);
                });
            });

            // Filter Items.
            Console.WriteLine("[Item] Processing...");
            var itemExH = new ExHFile(sqCache.GetFile("exd", "Item.exh"));
            itemExH.Iterate(sqCache, "exd", "Item_{0}_en.exd", exDFile =>
            {
                exDFile.Iterate(row =>
                {
                    var item = ItemFactory.CreateItemFromRow(row);

                    if (item != null)
                    {
                        item.NameEn = item.GetNameFromRow(row);

                        var type = item.GetType();

                        if (type == typeof(MateriaItem))
                        {
                            var materiaItem = (MateriaItem) item;
                            var paramKey = materiaItem.Parameters.Keys.FirstOrDefault();

                            if (Utility.StatCodes.ContainsKey(paramKey))
                            {
                                var codeName = $"{Utility.StatCodes[paramKey]}{materiaItem.Parameters[paramKey]}";

                                MateriaItems.Add(row.Key, materiaItem);
                                MateriaItemCodeMapper.Add(codeName, row.Key);
                            }
                        }
                        else if (type == typeof(Meal))
                        {
                            Meals.Add(row.Key, (Meal) item);
                            MealNameMapper.Add(item.NameEn, row.Key);
                        }
                        else if (type == typeof(Equipment))
                        {
                            Equipments.Add(row.Key, (Equipment) item);
                            EquipmentNameMapper.Add(item.NameEn, row.Key);
                        }
                    }
                });
            });

            // Put korean names on items.
            sqCache = new SqCache(KoreanClientPath, "0a0000.win32.index", "0a0000.win32.dat0");
            Console.WriteLine("[Item] Processing NameKo...");
            itemExH = new ExHFile(sqCache.GetFile("exd", "Item.exh"));
            itemExH.Iterate(sqCache, "exd", "Item_{0}_ko.exd", exDFile =>
            {
                exDFile.Iterate(row =>
                {
                    var item = new Item(row);

                    if (item != null)
                    {
                        if (MateriaItems.ContainsKey(row.Key))
                            MateriaItems[row.Key].NameKo = item.GetNameFromRow(row);
                        else if (Meals.ContainsKey(row.Key))
                            Meals[row.Key].NameKo = item.GetNameFromRow(row);
                        else if (Equipments.ContainsKey(row.Key)) Equipments[row.Key].NameKo = item.GetNameFromRow(row);
                    }
                });
            });

            if (!Directory.Exists(OutputBasePath)) Directory.CreateDirectory(OutputBasePath);

            TableGenerator.GeneratePLD();

            _5._5.TableGenerator.GeneratePLD();
            _5._5.TableGenerator.GenerateWAR();
            _5._5.TableGenerator.GenerateDRK();
            _5._5.TableGenerator.GenerateGNB();

            _5._5.TableGenerator.GenerateWHM();
            _5._5.TableGenerator.GenerateSCH();
            _5._5.TableGenerator.GenerateAST();

            _5._5.TableGenerator.GenerateMNK();
            _5._5.TableGenerator.GenerateDRG();
            _5._5.TableGenerator.GenerateNIN();
            _5._5.TableGenerator.GenerateSAM();

            _5._5.TableGenerator.GenerateBRD();
            _5._5.TableGenerator.GenerateMCH();
            _5._5.TableGenerator.GenerateDNC();

            _5._5.TableGenerator.GenerateBLM();
            _5._5.TableGenerator.GenerateSMN();
            _5._5.TableGenerator.GenerateRDM();
        }
    }
}