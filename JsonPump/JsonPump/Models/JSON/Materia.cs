using System;
using System.Linq;

namespace JsonPump.Models.JSON
{
    public class Materia
    {
        public Materia(string materiaCode)
        {
            Console.WriteLine($"\t\t=> Loading Materia {materiaCode}");

            if (Program.MateriaItemCodeMapper.ContainsKey(materiaCode))
            {
                var materiaItem = Program.MateriaItems[Program.MateriaItemCodeMapper[materiaCode]];
                nameEn = materiaItem.NameEn;
                nameKo = string.IsNullOrEmpty(materiaItem.NameKo) ? null : materiaItem.NameKo;
                iconSrc = Utility.GetImage(materiaItem);
                materiaNumber = materiaItem.Tier;

                var paramKey = materiaItem.Parameters.Keys.FirstOrDefault();
                var value = materiaItem.Parameters[paramKey];

                shortName = $"{Utility.StatShortNames[paramKey]}+{value}";
                attribute = new Attribute();

                switch (paramKey)
                {
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
            else if (materiaCode.Contains(" "))
            {
                attribute = new Attribute();
                nameEn = null;
                nameKo = null;
                iconSrc = null;
                materiaNumber = -1;

                var split = materiaCode.Split(" ");
                var value = int.Parse(split[1]);

                switch (split[0])
                {
                    case "ch":
                        shortName = $"극대+{split[1]}";
                        attribute.ch = value;
                        break;
                    case "dh":
                        shortName = $"직격+{split[1]}";
                        attribute.dh = value;
                        break;
                    case "det":
                        shortName = $"의지+{split[1]}";
                        attribute.det = value;
                        break;
                    case "sks":
                        shortName = $"기시+{split[1]}";
                        attribute.sks = value;
                        break;
                    case "sps":
                        shortName = $"마시+{split[1]}";
                        attribute.sps = value;
                        break;
                    case "ten":
                        shortName = $"불굴+{split[1]}";
                        attribute.ten = value;
                        break;
                    case "pie":
                        shortName = $"신앙+{split[1]}";
                        attribute.pie = value;
                        break;
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public string nameEn { get; set; }
        public string nameKo { get; set; }
        public string shortName { get; set; }
        public string iconSrc { get; set; }
        public int materiaNumber { get; set; }
        public Attribute attribute { get; set; }
    }
}