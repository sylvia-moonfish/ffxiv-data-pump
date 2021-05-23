using System.Collections.Generic;
using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public static class ItemFactory
    {
        public static Item CreateItemFromRow(ExDRow row)
        {
            var item = new Item(row);

            if (item.ItemUICategory.Name == "Materia") return new MateriaItem(row);

            if (item.ItemLevel >= 290)
            {
                if (item.ItemUICategory.Name == "Meal")
                    return new Meal(row);
                if (item.EquipSlotCategory.IsEquipment) return new Equipment(row);
            }

            return null;
        }
    }

    public class Item
    {
        public Item(ExDRow row)
        {
            ItemLevel = row.GetDataByIndex(11).GetAsTyped<ushort>();
            ItemUICategory = Program.ItemUICategories[row.GetDataByIndex(15).GetAsTyped<byte>()];
            EquipSlotCategory = Program.EquipSlotCategories[row.GetDataByIndex(17).GetAsTyped<byte>()];
        }

        public string NameEn { get; set; }
        public string NameKo { get; set; }
        public ushort ItemLevel { get; set; }
        public ItemUICategory ItemUICategory { get; set; }
        public EquipSlotCategory EquipSlotCategory { get; set; }

        public string GetNameFromRow(ExDRow row)
        {
            return row.GetDataByIndex(9).GetAsTyped<string>();
        }
    }

    public class MateriaItem : Item
    {
        public MateriaItem(ExDRow row) : base(row)
        {
            var materia = Program.Materias[row.Key];

            Tier = materia.Tier;

            Parameters = new Dictionary<string, short>();

            foreach (var key in materia.Parameters.Keys) Parameters.Add(key, materia.Parameters[key]);
        }

        public int Tier { get; set; }
        public Dictionary<string, short> Parameters { get; set; }
    }

    public class Meal : Item
    {
        public Meal(ExDRow row) : base(row)
        {
            var itemFoodValues = Program
                .ItemFoods[Program.ItemActions[row.GetDataByIndex(30).GetAsTyped<ushort>()].ItemFoodKey].Values;

            Parameters = new Dictionary<string, ItemFoodValue>();

            foreach (var key in itemFoodValues.Keys) Parameters.Add(key, itemFoodValues[key]);
        }

        public Dictionary<string, ItemFoodValue> Parameters { get; set; }
    }

    public class Equipment : Item
    {
        public Equipment(ExDRow row) : base(row)
        {
            Rarity = row.GetDataByIndex(12).GetAsTyped<byte>();

            CanBeHq = row.GetDataByIndex(27).GetAsTyped<bool>();

            ClassJobCategory = Program.ClassJobCategories[row.GetDataByIndex(43).GetAsTyped<byte>()];

            PhysicalDamage = row.GetDataByIndex(51).GetAsTyped<ushort>();

            MagicalDamage = row.GetDataByIndex(52).GetAsTyped<ushort>();

            Parameters = new Dictionary<string, short>();

            for (var i = 0; i < 6; i++)
            {
                var name = Program.BaseParams[row.GetDataByIndex(59 + i * 2).GetAsTyped<byte>()].Name;

                if (!string.IsNullOrEmpty(name))
                    Parameters.Add(name, row.GetDataByIndex(60 + i * 2).GetAsTyped<short>());
            }

            if (CanBeHq)
                for (var i = 0; i < 6; i++)
                {
                    var name = Program.BaseParams[row.GetDataByIndex(73 + i * 2).GetAsTyped<byte>()].Name;

                    if (!string.IsNullOrEmpty(name) && Parameters.ContainsKey(name))
                        Parameters[name] += row.GetDataByIndex(74 + i * 2).GetAsTyped<short>();
                }

            MateriaSlotCount = row.GetDataByIndex(86).GetAsTyped<byte>();

            IsOvermeldable = row.GetDataByIndex(87).GetAsTyped<bool>();
        }

        public byte Rarity { get; set; }
        public bool CanBeHq { get; set; }
        public ClassJobCategory ClassJobCategory { get; set; }
        public ushort PhysicalDamage { get; set; }
        public ushort MagicalDamage { get; set; }
        public Dictionary<string, short> Parameters { get; set; }
        public byte MateriaSlotCount { get; set; }
        public bool IsOvermeldable { get; set; }
    }
}