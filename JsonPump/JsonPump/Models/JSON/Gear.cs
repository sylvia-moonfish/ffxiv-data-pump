using System;
using System.Linq;

namespace JsonPump.Models.JSON
{
    public class Gear
    {
        public Gear(string equipmentName, params string[] materiaCodes)
        {
            Console.WriteLine($"\t=> Loading Gear {equipmentName}");

            var equipment = Program.Equipments[Program.EquipmentNameMapper[equipmentName]];

            nameEn = equipment.NameEn;
            nameKo = string.IsNullOrEmpty(equipment.NameKo) ? null : equipment.NameKo;
            iconSrc = Utility.GetImage(equipment);
            type = Utility.GetEquipmentTypeName(equipment);

            var equipmentSource = Utility.GetEquipmentSource(equipment);
            from = equipmentSource.From;
            required = equipmentSource.Required;

            materiaSlots = equipment.MateriaSlotCount;
            overmeldSlots = equipment.CanBeHq && equipment.IsOvermeldable ? 5 - equipment.MateriaSlotCount : 0;

            attribute = new Attribute();

            if (equipment.ClassJobCategory.IsTank || equipment.ClassJobCategory.IsStrDps ||
                equipment.ClassJobCategory.IsDexDps)
                attribute.wd = equipment.PhysicalDamage;
            else if (equipment.ClassJobCategory.IsHealer || equipment.ClassJobCategory.IsIntDps)
                attribute.wd = equipment.MagicalDamage;

            foreach (var paramKey in equipment.Parameters.Keys)
            {
                var value = equipment.Parameters[paramKey];

                switch (paramKey)
                {
                    case "Strength":
                        attribute.str += value;
                        break;
                    case "Dexterity":
                        attribute.dex += value;
                        break;
                    case "Intelligence":
                        attribute.@int += value;
                        break;
                    case "Mind":
                        attribute.mnd += value;
                        break;
                    case "Critical Hit":
                        attribute.ch += value;
                        break;
                    case "Direct Hit Rate":
                        attribute.dh += value;
                        break;
                    case "Determination":
                        attribute.det += value;
                        break;
                    case "Skill Speed":
                        attribute.sks += value;
                        break;
                    case "Spell Speed":
                        attribute.sps += value;
                        break;
                    case "Tenacity":
                        attribute.ten += value;
                        break;
                    case "Piety":
                        attribute.pie += value;
                        break;
                }
            }

            materias = materiaCodes.Select(materiaCode => new Materia(materiaCode)).ToArray();
        }

        public string nameEn { get; set; }
        public string nameKo { get; set; }
        public string iconSrc { get; set; }
        public string type { get; set; }
        public string from { get; set; }
        public string required { get; set; }
        public int materiaSlots { get; set; }
        public int overmeldSlots { get; set; }
        public Attribute attribute { get; set; }
        public Materia[] materias { get; set; }

        public Attribute GetTotalAttribute()
        {
            var totalAttribute = new Attribute();
            totalAttribute.Add(attribute);

            var max = new[]
            {
                attribute.ch, attribute.dh, attribute.det, attribute.sks, attribute.sps, attribute.ten,
                attribute.pie
            }.Max();

            foreach (var materia in materias)
            {
                if (string.IsNullOrEmpty(materia.nameEn))
                {
                    totalAttribute.Add(materia.attribute);
                }
                else
                {
                    totalAttribute.Add(materia.attribute, max);
                }
            }

            return totalAttribute;
        }
    }
}