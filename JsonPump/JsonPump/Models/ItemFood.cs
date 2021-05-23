using System.Collections.Generic;
using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public class ItemFood
    {
        public ItemFood(ExDRow row)
        {
            RowKey = row.Key;

            Values = new Dictionary<string, ItemFoodValue>();

            for (var i = 0; i < 3; i++)
            {
                var baseParamName = Program.BaseParams[row.GetDataByIndex(1 + i * 6).GetAsTyped<byte>()].Name;

                if (!string.IsNullOrEmpty(baseParamName))
                    Values.Add(baseParamName,
                        new ItemFoodValue
                        {
                            Value = row.GetDataByIndex(5 + i * 6).GetAsTyped<sbyte>(),
                            Max = row.GetDataByIndex(6 + i * 6).GetAsTyped<short>()
                        });
            }
        }

        public int RowKey { get; set; }
        public Dictionary<string, ItemFoodValue> Values { get; set; }
    }

    public class ItemFoodValue
    {
        public sbyte Value { get; set; }
        public short Max { get; set; }
    }
}