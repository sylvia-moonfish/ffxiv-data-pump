using DataPump.SquareEnix.ExFiles;
using DataPump.Utility;
using System.ComponentModel.DataAnnotations;

namespace DataPump.Database.Models
{
    public class ItemModel : ItemBaseModel
    {
        [Key]
        public int Key { get; set; }
        public int[] LastUpdated { get; set; }
    }

    public class ItemBaseModel : RowKeyModel
    {
        public string NameEn { get; set; }
        public string NameJa { get; set; }
        public string NameKo { get; set; }
        public byte EquipLevel { get; set; }
        public byte MateriaSlotCount { get; set; }

        public void SetFromRow(ExDRow row, string languageCode)
        {
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

            EquipLevel = row.GetDataByIndex(40).GetAsTyped<byte>();

            MateriaSlotCount = row.GetDataByIndex(86).GetAsTyped<byte>();
        }
    }
}
