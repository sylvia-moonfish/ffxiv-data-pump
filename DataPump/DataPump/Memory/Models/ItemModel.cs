using DataPump.SquareEnix.ExFiles;
using DataPump.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataPump.Memory.Models
{
    public class ItemModel : ItemBaseModel
    {
        [Key]
        public int Key { get; set; }
    }

    public class ItemBaseModel : RowKeyModel
    {
        public string NameEn { get; set; }
        public string NameJa { get; set; }
        public string NameKo { get; set; }
        public ushort ItemLevel { get; set; }
        public ItemUICategoryModel ItemUICategory { get; set; }
        public EquipSlotCategoryModel EquipSlotCategory { get; set; }
        public bool CanBeHq { get; set; }
        public ClassJobCategoryModel ClassJobCategory { get; set; }
        public List<ParameterValueModel> ParameterValues { get; set; }
        public byte MateriaSlotCount { get; set; }

        public ushort GetItemLevelFromRow(ExDRow row)
        {
            return row.GetDataByIndex(11).GetAsTyped<ushort>();
        }

        public ItemUICategoryModel GetItemUICategoryFromRow(ExDRow row)
        {
            return Program.memoryContext.ItemUICategories.FirstOrDefault(itemUICategory => itemUICategory.RowKey == row.GetDataByIndex(15).GetAsTyped<byte>());
        }

        public void SetFromRow(ExDRow row, string languageCode)
        {
            RowKey = row.Key;

            switch (languageCode)
            {
                case "en":
                    NameEn = row.GetDataByIndex(9).GetAsTyped<string>();
                    break;
                case "ja":
                    NameJa = row.GetDataByIndex(9).GetAsTyped<string>();
                    break;
                case "ko":
                    NameKo = row.GetDataByIndex(9).GetAsTyped<string>();
                    break;
            }

            ItemLevel = GetItemLevelFromRow(row);

            ItemUICategory = GetItemUICategoryFromRow(row);
            
            EquipSlotCategory = Program.memoryContext.EquipSlotCategories.FirstOrDefault(equipSlotCategory => equipSlotCategory.RowKey == row.GetDataByIndex(17).GetAsTyped<byte>());
            
            CanBeHq = row.GetDataByIndex(27).GetAsTyped<bool>();
            
            ClassJobCategory = Program.memoryContext.ClassJobCategories.FirstOrDefault(classJobCategory => classJobCategory.RowKey == row.GetDataByIndex(43).GetAsTyped<byte>());
            
            ParameterValues = new List<ParameterValueModel>();
            
            for (int i = 0; i < 6; i++)
            {
                ParameterValueModel parameterValue = new ParameterValueModel()
                {
                    BaseParam = Program.memoryContext.BaseParams.FirstOrDefault(baseParam => baseParam.RowKey == row.GetDataByIndex(59 + i * 2).GetAsTyped<byte>()),
                    ParamValue = row.GetDataByIndex(60 + i * 2).GetAsTyped<short>()
                };

                ParameterValues.Add(parameterValue);
            }

            MateriaSlotCount = row.GetDataByIndex(86).GetAsTyped<byte>();
        }
    }
}
