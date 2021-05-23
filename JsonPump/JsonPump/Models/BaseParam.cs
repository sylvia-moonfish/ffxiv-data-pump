using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public class BaseParam
    {
        public BaseParam(ExDRow row)
        {
            RowKey = row.Key;
            Name = row.GetDataByIndex(1).GetAsTyped<string>();
        }

        public int RowKey { get; set; }
        public string Name { get; set; }
    }
}