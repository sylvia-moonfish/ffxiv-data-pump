using DataPump.SquareEnix.ExFiles;
using DataPump.Utility;
using System.ComponentModel.DataAnnotations;

namespace DataPump.Memory.Models
{
    public class ItemUICategoryModel : ItemUICategoryBaseModel
    {
        [Key]
        public int Key { get; set; }
    }

    public class ItemUICategoryBaseModel : RowKeyModel
    {
        public string Name { get; set; }

        public void SetFromRow(ExDRow row)
        {
            RowKey = row.Key;

            Name = row.GetDataByIndex(0).GetAsTyped<string>();
        }
    }
}
