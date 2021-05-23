using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public class ItemUICategory
    {
        public ItemUICategory(ExDRow row)
        {
            RowKey = row.Key;
            Name = row.GetDataByIndex(0).GetAsTyped<string>();
        }

        public int RowKey { get; set; }
        public string Name { get; set; }
    }
}