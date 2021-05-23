using DataPump.SquareEnix.ExFiles;
using DataPump.Utility;
using System.ComponentModel.DataAnnotations;

namespace DataPump.Memory.Models
{
    public class ClassJobCategoryModel : ClassJobCategoryBaseModel
    {
        [Key]
        public int Key { get; set; }
    }

    public class ClassJobCategoryBaseModel : RowKeyModel
    {
        public string Name { get; set; }
        public bool ADV { get; set; }
        public bool GLA { get; set; }
        public bool PGL { get; set; }
        public bool MRD { get; set; }
        public bool LNC { get; set; }
        public bool ARC { get; set; }
        public bool CNJ { get; set; }
        public bool THM { get; set; }
        public bool CRP { get; set; }
        public bool BSM { get; set; }
        public bool ARM { get; set; }
        public bool GSM { get; set; }
        public bool LTW { get; set; }
        public bool WVR { get; set; }
        public bool ALC { get; set; }
        public bool CUL { get; set; }
        public bool MIN { get; set; }
        public bool BTN { get; set; }
        public bool FSH { get; set; }
        public bool PLD { get; set; }
        public bool MNK { get; set; }
        public bool WAR { get; set; }
        public bool DRG { get; set; }
        public bool BRD { get; set; }
        public bool WHM { get; set; }
        public bool BLM { get; set; }
        public bool ACN { get; set; }
        public bool SMN { get; set; }
        public bool SCH { get; set; }
        public bool ROG { get; set; }
        public bool NIN { get; set; }
        public bool MCH { get; set; }
        public bool DRK { get; set; }
        public bool AST { get; set; }
        public bool SAM { get; set; }
        public bool RDM { get; set; }
        public bool BLU { get; set; }
        public bool GNB { get; set; }
        public bool DNC { get; set; }
        
        public void SetFromRow(ExDRow row)
        {
            RowKey = row.Key;

            Name = row.GetDataByIndex(0).GetAsTyped<string>();
            ADV = row.GetDataByIndex(1).GetAsTyped<bool>();
            GLA = row.GetDataByIndex(2).GetAsTyped<bool>();
            PGL = row.GetDataByIndex(3).GetAsTyped<bool>();
            MRD = row.GetDataByIndex(4).GetAsTyped<bool>();
            LNC = row.GetDataByIndex(5).GetAsTyped<bool>();
            ARC = row.GetDataByIndex(6).GetAsTyped<bool>();
            CNJ = row.GetDataByIndex(7).GetAsTyped<bool>();
            THM = row.GetDataByIndex(8).GetAsTyped<bool>();
            CRP = row.GetDataByIndex(9).GetAsTyped<bool>();
            BSM = row.GetDataByIndex(10).GetAsTyped<bool>();
            ARM = row.GetDataByIndex(11).GetAsTyped<bool>();
            GSM = row.GetDataByIndex(12).GetAsTyped<bool>();
            LTW = row.GetDataByIndex(13).GetAsTyped<bool>();
            WVR = row.GetDataByIndex(14).GetAsTyped<bool>();
            ALC = row.GetDataByIndex(15).GetAsTyped<bool>();
            CUL = row.GetDataByIndex(16).GetAsTyped<bool>();
            MIN = row.GetDataByIndex(17).GetAsTyped<bool>();
            BTN = row.GetDataByIndex(18).GetAsTyped<bool>();
            FSH = row.GetDataByIndex(19).GetAsTyped<bool>();
            PLD = row.GetDataByIndex(20).GetAsTyped<bool>();
            MNK = row.GetDataByIndex(21).GetAsTyped<bool>();
            WAR = row.GetDataByIndex(22).GetAsTyped<bool>();
            DRG = row.GetDataByIndex(23).GetAsTyped<bool>();
            BRD = row.GetDataByIndex(24).GetAsTyped<bool>();
            WHM = row.GetDataByIndex(25).GetAsTyped<bool>();
            BLM = row.GetDataByIndex(26).GetAsTyped<bool>();
            ACN = row.GetDataByIndex(27).GetAsTyped<bool>();
            SMN = row.GetDataByIndex(28).GetAsTyped<bool>();
            SCH = row.GetDataByIndex(29).GetAsTyped<bool>();
            ROG = row.GetDataByIndex(30).GetAsTyped<bool>();
            NIN = row.GetDataByIndex(31).GetAsTyped<bool>();
            MCH = row.GetDataByIndex(32).GetAsTyped<bool>();
            DRK = row.GetDataByIndex(33).GetAsTyped<bool>();
            AST = row.GetDataByIndex(34).GetAsTyped<bool>();
            SAM = row.GetDataByIndex(35).GetAsTyped<bool>();
            RDM = row.GetDataByIndex(36).GetAsTyped<bool>();
            BLU = row.GetDataByIndex(37).GetAsTyped<bool>();
            GNB = row.GetDataByIndex(38).GetAsTyped<bool>();
            DNC = row.GetDataByIndex(39).GetAsTyped<bool>();
        }
    }
}
