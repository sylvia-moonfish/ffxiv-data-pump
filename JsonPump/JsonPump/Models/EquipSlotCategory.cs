using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public class EquipSlotCategory
    {
        public EquipSlotCategory(ExDRow row)
        {
            RowKey = row.Key;
            MainHand = row.GetDataByIndex(0).GetAsTyped<sbyte>() > 0;
            OffHand = row.GetDataByIndex(1).GetAsTyped<sbyte>() > 0;
            Head = row.GetDataByIndex(2).GetAsTyped<sbyte>() > 0;
            Body = row.GetDataByIndex(3).GetAsTyped<sbyte>() > 0;
            Gloves = row.GetDataByIndex(4).GetAsTyped<sbyte>() > 0;
            Waist = row.GetDataByIndex(5).GetAsTyped<sbyte>() > 0;
            Legs = row.GetDataByIndex(6).GetAsTyped<sbyte>() > 0;
            Feet = row.GetDataByIndex(7).GetAsTyped<sbyte>() > 0;
            Ears = row.GetDataByIndex(8).GetAsTyped<sbyte>() > 0;
            Neck = row.GetDataByIndex(9).GetAsTyped<sbyte>() > 0;
            Wrists = row.GetDataByIndex(10).GetAsTyped<sbyte>() > 0;
            Ring = row.GetDataByIndex(11).GetAsTyped<sbyte>() > 0 || row.GetDataByIndex(12).GetAsTyped<sbyte>() > 0;
        }

        public int RowKey { get; set; }
        public bool MainHand { get; set; }
        public bool OffHand { get; set; }
        public bool Head { get; set; }
        public bool Body { get; set; }
        public bool Gloves { get; set; }
        public bool Waist { get; set; }
        public bool Legs { get; set; }
        public bool Feet { get; set; }
        public bool Ears { get; set; }
        public bool Neck { get; set; }
        public bool Wrists { get; set; }
        public bool Ring { get; set; }

        public bool IsEquipment =>
            MainHand || OffHand || Head || Body || Gloves || Waist || Legs || Feet || Ears || Neck || Wrists || Ring;

        public bool IsWeapon => MainHand;

        public bool IsArmor => OffHand || Head || Body || Gloves || Waist || Legs || Feet;

        public bool IsAcc => Ears || Neck || Wrists || Ring;
    }
}