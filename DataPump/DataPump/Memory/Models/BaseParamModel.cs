using DataPump.SquareEnix.ExFiles;
using DataPump.Utility;
using System.ComponentModel.DataAnnotations;

namespace DataPump.Memory.Models
{
    public class BaseParamModel : BaseParamBaseModel
    {
        [Key]
        public int Key { get; set; }
    }

    public class BaseParamBaseModel : RowKeyModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void SetFromRow(ExDRow row)
        {
            RowKey = row.Key;

            Name = row.GetDataByIndex(1).GetAsTyped<string>();
            Description = row.GetDataByIndex(2).GetAsTyped<string>();
        }
    }
}
