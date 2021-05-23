using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public class ItemAction
    {
        public ItemAction(ExDRow row)
        {
            RowKey = row.Key;
            ItemFoodKey = row.GetDataByIndex(15).GetAsTyped<ushort>();
        }

        public int RowKey { get; set; }
        public ushort ItemFoodKey { get; set; }
    }
}