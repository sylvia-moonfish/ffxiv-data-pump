using DataPump.SquareEnix.ExFiles;
using DataPump.Utility;
using System.ComponentModel.DataAnnotations;

namespace DataPump.Memory.Models
{
    public class EquipSlotCategoryModel : EquipSlotCategoryBaseModel
    {
        [Key]
        public int Key { get; set; }
    }

    public class EquipSlotCategoryBaseModel : RowKeyModel
    {
        public sbyte MainHand { get; set; }
        public sbyte OffHand { get; set; }
        public sbyte Head { get; set; }
        public sbyte Body { get; set; }
        public sbyte Gloves { get; set; }
        public sbyte Waist { get; set; }
        public sbyte Legs { get; set; }
        public sbyte Feet { get; set; }
        public sbyte Ears { get; set; }
        public sbyte Neck { get; set; }
        public sbyte Wrists { get; set; }
        public sbyte FingerL { get; set; }
        public sbyte FingerR { get; set; }
        public sbyte SoulCrystal { get; set; }

        public void SetFromRow(ExDRow row)
        {
            RowKey = row.Key;

            MainHand = row.GetDataByIndex(0).GetAsTyped<sbyte>();
            OffHand = row.GetDataByIndex(1).GetAsTyped<sbyte>();
            Head = row.GetDataByIndex(2).GetAsTyped<sbyte>();
            Body = row.GetDataByIndex(3).GetAsTyped<sbyte>();
            Gloves = row.GetDataByIndex(4).GetAsTyped<sbyte>();
            Waist = row.GetDataByIndex(5).GetAsTyped<sbyte>();
            Legs = row.GetDataByIndex(6).GetAsTyped<sbyte>();
            Feet = row.GetDataByIndex(7).GetAsTyped<sbyte>();
            Ears = row.GetDataByIndex(8).GetAsTyped<sbyte>();
            Neck = row.GetDataByIndex(9).GetAsTyped<sbyte>();
            Wrists = row.GetDataByIndex(10).GetAsTyped<sbyte>();
            FingerL = row.GetDataByIndex(11).GetAsTyped<sbyte>();
            FingerR = row.GetDataByIndex(12).GetAsTyped<sbyte>();
            SoulCrystal = row.GetDataByIndex(13).GetAsTyped<sbyte>();
        }
    }
}
