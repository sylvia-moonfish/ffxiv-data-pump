using DataPump.Database;
using DataPump.Memory;
using DataPump.SquareEnix;
using DataPump.SquareEnix.ExFiles;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataPump
{
    public class Program
    {
        // Database connection information.
        public static string DatabaseHost = "localhost";
        public static string DatabaseUsername = "postgres";
        public static string DatabasePassword = "testing";
        public static string DatabaseName = "ffxiv";

        // Versions have to be set manually before pumping data into database!
        public static int[] GlobalVersion = { 5, 5, 0 };

        // Game client installation path. Change as necessary.
        public static string GlobalClientPath = @"C:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn\game\sqpack\ffxiv";
        public static string KoreanClientPath = @"C:\Program Files (x86)\FINAL FANTASY XIV - KOREA\game\sqpack\ffxiv";

        // Just make it accessible everywhere because I'm lazy.
        public static MemoryContext memoryContext;
        public static FfxivContext ffxivContext;

        static void Main()
        {
            using (memoryContext = new MemoryContext())
            using (ffxivContext = new FfxivContext())
            {
                // Create sqlite database in memory for data processing...
                Console.WriteLine("[Memory] Creating temporary database...");
                Console.WriteLine();
                memoryContext.Database.EnsureCreated();

                // Read and cache global client data.
                SqCache sqCache = new SqCache(GlobalClientPath, "0a0000.win32.index", "0a0000.win32.dat0");

                // Process BaseParam into memory.
                Console.WriteLine("[Memory][BaseParam] Processing...");
                ExHFile baseParamExH = new ExHFile(sqCache.GetFile("exd", "BaseParam.exh"));
                baseParamExH.Iterate(sqCache, "exd", "BaseParam_{0}_en.exd", exDFile => {
                    exDFile.Iterate(row => {
                        Memory.Models.BaseParamModel baseParam = new Memory.Models.BaseParamModel();
                        baseParam.SetFromRow(row);
                        memoryContext.Add(baseParam);
                    });
                });
                Console.WriteLine("[Memory][BaseParam] Saving...");
                Console.WriteLine();
                memoryContext.SaveChanges();

                // Process ClassJobCategory into memory.
                Console.WriteLine("[Memory][ClassJobCategory] Processing...");
                ExHFile classJobCategoryExH = new ExHFile(sqCache.GetFile("exd", "ClassJobCategory.exh"));
                classJobCategoryExH.Iterate(sqCache, "exd", "ClassJobCategory_{0}_en.exd", exDFile => {
                    exDFile.Iterate(row => {
                        Memory.Models.ClassJobCategoryModel classJobCategory = new Memory.Models.ClassJobCategoryModel();
                        classJobCategory.SetFromRow(row);
                        memoryContext.Add(classJobCategory);
                    });
                });
                Console.WriteLine("[Memory][ClassJobCategory] Saving...");
                Console.WriteLine();
                memoryContext.SaveChanges();

                // Process EquipSlotCategory into memory.
                Console.WriteLine("[Memory][EquipSlotCategory] Processing...");
                ExHFile equipSlotCategoryExH = new ExHFile(sqCache.GetFile("exd", "EquipSlotCategory.exh"));
                equipSlotCategoryExH.Iterate(sqCache, "exd", "EquipSlotCategory_{0}.exd", exDFile => {
                    exDFile.Iterate(row => {
                        Memory.Models.EquipSlotCategoryModel equipSlotCategory = new Memory.Models.EquipSlotCategoryModel();
                        equipSlotCategory.SetFromRow(row);
                        memoryContext.Add(equipSlotCategory);
                    });
                });
                Console.WriteLine("[Memory][EquipSlotCategory] Saving...");
                Console.WriteLine();
                memoryContext.SaveChanges();

                // Process ItemUICategory into memory.
                Console.WriteLine("[Memory][ItemUICategory] Processing...");
                ExHFile itemUICategoryExH = new ExHFile(sqCache.GetFile("exd", "ItemUICategory.exh"));
                itemUICategoryExH.Iterate(sqCache, "exd", "ItemUICategory_{0}_en.exd", exDFile => {
                    exDFile.Iterate(row => {
                        Memory.Models.ItemUICategoryModel itemUICategory = new Memory.Models.ItemUICategoryModel();
                        itemUICategory.SetFromRow(row);
                        memoryContext.Add(itemUICategory);
                    });
                });
                Console.WriteLine("[Memory][ItemUICategory] Saving...");
                Console.WriteLine();
                memoryContext.SaveChanges();

                string[] equipmentCategories = {
                    "Pugilist's Arm",
                    "Gladiator's Arm",
                    "Marauder's Arm",
                    "Archer's Arm",
                    "Lancer's Arm",
                    "One-handed Thaumaturge's Arm",
                    "Two-handed Thaumaturge's Arm",
                    "One-handed Conjurer's Arm",
                    "Two-handed Conjurer's Arm",
                    "Arcanist's Grimoire",
                    "Shield",
                    "Head",
                    "Body",
                    "Legs",
                    "Hands",
                    "Feet",
                    "Waist",
                    "Necklace",
                    "Earrings",
                    "Bracelets",
                    "Ring",
                    "Rogue's Arm",
                    "Dark Knight's Arm",
                    "Machinist's Arm",
                    "Astrologian's Arm",
                    "Samurai's Arm",
                    "Red Mage's Arm",
                    "Scholar's Arm",
                    "Blue Mage's Arm",
                    "Gunbreaker's Arm",
                    "Dancer's Arm"
                };

                // Process Item into memory.
                Console.WriteLine("[Memory][Item] Processing...");
                ExHFile itemExH = new ExHFile(sqCache.GetFile("exd", "Item.exh"));
                itemExH.Iterate(sqCache, "exd", "Item_{0}_en.exd", exDFile => {
                    exDFile.Iterate(row => {
                        Memory.Models.ItemModel item = new Memory.Models.ItemModel();
                        
                        Memory.Models.ItemUICategoryModel itemUICategory = item.GetItemUICategoryFromRow(row);
                        ushort itemLevel = item.GetItemLevelFromRow(row);

                        if (equipmentCategories.Contains(itemUICategory.Name) && itemLevel >= 430)
                        {
                            item.SetFromRow(row, "en");
                            memoryContext.Equipments.Add(item);
                        }
                        else if (itemUICategory.Name == "Meal" && itemLevel >= 430)
                        {
                            item.SetFromRow(row, "en");
                            memoryContext.Foods.Add(item);
                        }
                        else if (itemUICategory.Name == "Materia")
                        {
                            item.SetFromRow(row, "en");
                            memoryContext.Materias.Add(item);
                        }
                    });
                });
                Console.WriteLine("[Memory][Item] Saving...");
                Console.WriteLine();
                memoryContext.SaveChanges();

                // Process Item.
                /*Console.WriteLine("[Item] Processing...");
                ExHFile globalItemExH = new ExHFile(globalSqCache.GetFile("exd", "Item.exh"));
                globalItemExH.Iterate(globalSqCache, "exd", "Item_{0}_en.exd", exDFile =>
                {
                    exDFile.Iterate(row =>
                    {
                        // Construct new item model from row.
                        ItemModel item = new ItemModel()
                        {
                            RowKey = row.Key,
                            LastUpdated = GlobalVersion
                        };
                        item.SetFromRow(row, "en");

                        // See if item with the same row key already exists in the database.
                        ItemModel existingItem = ffxivContext.Items.FirstOrDefault(_item => _item.RowKey == item.RowKey);

                        // If doesn't exist, insert it.
                        if (existingItem == null)
                        {
                            ffxivContext.Add(item);
                        }
                        // If does exist, compare values and update it only if necessary.
                        else
                        {
                            item.NameJa = existingItem.NameJa;
                            item.NameKo = existingItem.NameKo;

                            if (!Utility.Equals<ItemBaseModel>(item, existingItem))
                            {
                                // Update to current values and set last updated patch version to current version.
                                Utility.Set<ItemBaseModel>(existingItem, item);
                                existingItem.LastUpdated = GlobalVersion;
                            }
                        }

                        ffxivContext.SaveChanges();
                    });
                });
                */
            }
        }

        // Print a progress bar on the console.
        static string prevLine = string.Empty;
        public static void ReportProgress(double progress)
        {
            // Remove the progress bar that was printed on the previous step, if it exists.
            if (!string.IsNullOrEmpty(prevLine))
            {
                // Create a blank line that has the same length as the previous progress bar.
                string cleanLine = string.Empty;
                while (cleanLine.Length != prevLine.Length) cleanLine += " ";

                // Print carriage return to move cursor to the front.
                Console.Write("\r");

                // Overwrite blank line on top of the previous progress bar.
                Console.Write(cleanLine);
            }

            // Print carriage return to move cursor to the front.
            Console.Write("\r");

            // Create and print progress bar line.
            string progressBar = "[";

            for (int i = 1; i <= 20; i++)
            {
                if (i <= (progress * 20))
                {
                    progressBar += "#";
                }
                else
                {
                    progressBar += " ";
                }
            }

            progressBar += $"] {Math.Round(progress * 100)}%";

            Console.Write(progressBar);

            // If this is the last step...
            if (Math.Floor(progress) == 1)
            {
                prevLine = string.Empty;
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                prevLine = progressBar;
            }
        }

        // Print a second progress bar to the right of the first progress bar.
        static string prevSecondLine = string.Empty;
        public static void ReportInnerProgress(double progress)
        {
            // Remove the progress bar that was printed on the previous step, if it exists.
            int lineCleanLength = -1;

            // If second progress bar was already printed, remove that.
            if (!string.IsNullOrEmpty(prevSecondLine)) lineCleanLength = prevSecondLine.Length;

            // Else, just remove the first progress bar if it exists.
            else if (!string.IsNullOrEmpty(prevLine)) lineCleanLength = prevLine.Length;
            
            if (lineCleanLength > 0)
            {
                // Create a blank line that has the same length as the previous progress bar.
                string cleanLine = string.Empty;
                while (cleanLine.Length != lineCleanLength) cleanLine += " ";

                // Print carriage return to move cursor to the front.
                Console.Write("\r");

                // Overwrite blank line on top of the previous progress bar.
                Console.Write(cleanLine);
            }

            // Print carriage return to move cursor to the front.
            Console.Write("\r");

            // Create and print progress bar line.
            string progressBar = $"{prevLine} => [";

            for (int i = 1; i <= 20; i++)
            {
                if (i <= (progress * 20))
                {
                    progressBar += "#";
                }
                else
                {
                    progressBar += " ";
                }
            }

            progressBar += $"] {Math.Round(progress * 100)}%";

            Console.Write(progressBar);

            // If this is the last step...
            if (Math.Floor(progress) == 1)
            {
                // Mark the whole line as previous line that should be cleaned.
                prevLine = progressBar;
                prevSecondLine = string.Empty;
            }
            else
            {
                prevSecondLine = progressBar;
            }
        }

        // Debugging purposes.
        private static void PrintExD(ExDFile file, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{fileName}.csv"), false))
            {
                foreach (ExDRow row in file.Rows)
                {
                    for (int i = 0; i < file.Header.Columns.Length; i++)
                    {
                        sw.Write($"\"Column {i}: {row.GetDataByIndex(i).Value}\",");
                    }

                    sw.WriteLine();
                }
            }
        }
    }
}
