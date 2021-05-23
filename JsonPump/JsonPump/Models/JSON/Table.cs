using System;

namespace JsonPump.Models.JSON
{
    public class Table
    {
        public Table(string title, string description, ClassJobCategory classJobCategory, params GearSet[] gearSets)
        {
            this.title = title;
            this.description = description;
            this.gearSets = gearSets;

            columnDefinitions = GetColumnDefinitions(classJobCategory);
            statDefinitions = GetStatDefinitions(classJobCategory);

            var mainAttribute = GetMainAttribute(classJobCategory);

            for (var i = 0; i < gearSets.Length; i++)
            {
                var gearSet = gearSets[i];

                if (gearSet.attribute == null)
                {
                    gearSet.attribute = new Attribute();
                    gearSet.attribute.Add(mainAttribute);
                    var totalAttribute = gearSet.GetTotalAttribute();
                    gearSet.attribute.Add(totalAttribute);
                    gearSet.attribute.ApplyFood(gearSet.meal.mealAttribute);
                }

                if (gearSet.title.Contains("절 바하무트") || gearSet.title.Contains("절 알테마"))
                    gearSet.Calculate70(classJobCategory);
                else
                    gearSet.Calculate(classJobCategory);
            }
        }

        public string title { get; set; }
        public string description { get; set; }
        public ColumnDefinition[] columnDefinitions { get; set; }
        public StatDefinition[] statDefinitions { get; set; }
        public GearSet[] gearSets { get; set; }

        public ColumnDefinition[] GetColumnDefinitions(ClassJobCategory classJobCategory)
        {
            if (classJobCategory.IsTank)
                return new[]
                {
                    new("dps"), new ColumnDefinition("gcd"), new ColumnDefinition("mealName"),
                    new ColumnDefinition("ch"), new ColumnDefinition("dh"), new ColumnDefinition("ten")
                };
            if (classJobCategory.IsHealer)
                return new[]
                {
                    new("dps"), new ColumnDefinition("hps"), new ColumnDefinition("mpRegen"),
                    new ColumnDefinition("gcd"), new ColumnDefinition("mealName"), new ColumnDefinition("ch"),
                    new ColumnDefinition("dh")
                };
            if (classJobCategory.MNK)
                return new[]
                {
                    new("dps"), new ColumnDefinition("gcd"), new ColumnDefinition("glGcd"),
                    new ColumnDefinition("mealName"), new ColumnDefinition("ch"), new ColumnDefinition("dh")
                };
            if (classJobCategory.NIN)
                return new[]
                {
                    new("dps"), new ColumnDefinition("gcd"), new ColumnDefinition("hutonGcd"),
                    new ColumnDefinition("mealName"), new ColumnDefinition("ch"), new ColumnDefinition("dh")
                };
            if (classJobCategory.SAM)
                return new[]
                {
                    new("dps"), new ColumnDefinition("gcd"), new ColumnDefinition("shifuGcd"),
                    new ColumnDefinition("rotation"), new ColumnDefinition("mealName"), new ColumnDefinition("ch"),
                    new ColumnDefinition("dh")
                };
            return new[]
            {
                new("dps"), new ColumnDefinition("gcd"), new ColumnDefinition("mealName"),
                new ColumnDefinition("ch"), new ColumnDefinition("dh")
            };
        }

        public StatDefinition[] GetStatDefinitions(ClassJobCategory classJobCategory)
        {
            if (classJobCategory.IsTank)
                return new[]
                {
                    new("str"), new StatDefinition("ch"), new StatDefinition("dh"), new StatDefinition("det"),
                    new StatDefinition("sks"), new StatDefinition("ten")
                };
            if (classJobCategory.IsHealer)
                return new[]
                {
                    new("mnd"), new StatDefinition("ch"), new StatDefinition("dh"), new StatDefinition("det"),
                    new StatDefinition("sps"), new StatDefinition("pie")
                };
            if (classJobCategory.IsStrDps)
                return new[]
                {
                    new("str"), new StatDefinition("ch"), new StatDefinition("dh"), new StatDefinition("det"),
                    new StatDefinition("sks")
                };
            if (classJobCategory.IsDexDps)
                return new[]
                {
                    new("dex"), new StatDefinition("ch"), new StatDefinition("dh"), new StatDefinition("det"),
                    new StatDefinition("sks")
                };
            return new[]
            {
                new("int"), new StatDefinition("ch"), new StatDefinition("dh"), new StatDefinition("det"),
                new StatDefinition("sps")
            };
        }

        public Attribute GetClassAttribute(ClassJobCategory classJobCategory)
        {
            var classAttribute = new Attribute();

            if (classJobCategory.PLD)
            {
                classAttribute.str = 100;
                classAttribute.dex = 95;
                classAttribute.@int = 60;
                classAttribute.mnd = 100;
            }
            else if (classJobCategory.WAR)
            {
                classAttribute.str = 105;
                classAttribute.dex = 95;
                classAttribute.@int = 40;
                classAttribute.mnd = 55;
            }
            else if (classJobCategory.DRK)
            {
                classAttribute.str = 105;
                classAttribute.dex = 95;
                classAttribute.@int = 60;
                classAttribute.mnd = 40;
            }
            else if (classJobCategory.GNB)
            {
                classAttribute.str = 100;
                classAttribute.dex = 95;
                classAttribute.@int = 60;
                classAttribute.mnd = 100;
            }
            else if (classJobCategory.WHM)
            {
                classAttribute.str = 55;
                classAttribute.dex = 105;
                classAttribute.@int = 105;
                classAttribute.mnd = 115;
            }
            else if (classJobCategory.SCH)
            {
                classAttribute.str = 90;
                classAttribute.dex = 100;
                classAttribute.@int = 105;
                classAttribute.mnd = 115;
            }
            else if (classJobCategory.AST)
            {
                classAttribute.str = 50;
                classAttribute.dex = 100;
                classAttribute.@int = 105;
                classAttribute.mnd = 115;
            }
            else if (classJobCategory.MNK)
            {
                classAttribute.str = 110;
                classAttribute.dex = 105;
                classAttribute.@int = 50;
                classAttribute.mnd = 90;
            }
            else if (classJobCategory.DRG)
            {
                classAttribute.str = 115;
                classAttribute.dex = 100;
                classAttribute.@int = 45;
                classAttribute.mnd = 65;
            }
            else if (classJobCategory.NIN)
            {
                classAttribute.str = 85;
                classAttribute.dex = 110;
                classAttribute.@int = 65;
                classAttribute.mnd = 75;
            }
            else if (classJobCategory.SAM)
            {
                classAttribute.str = 112;
                classAttribute.dex = 108;
                classAttribute.@int = 60;
                classAttribute.mnd = 50;
            }
            else if (classJobCategory.BRD)
            {
                classAttribute.str = 90;
                classAttribute.dex = 115;
                classAttribute.@int = 85;
                classAttribute.mnd = 80;
            }
            else if (classJobCategory.MCH)
            {
                classAttribute.str = 85;
                classAttribute.dex = 115;
                classAttribute.@int = 80;
                classAttribute.mnd = 85;
            }
            else if (classJobCategory.DNC)
            {
                classAttribute.str = 90;
                classAttribute.dex = 115;
                classAttribute.@int = 85;
                classAttribute.mnd = 80;
            }
            else if (classJobCategory.BLM)
            {
                classAttribute.str = 45;
                classAttribute.dex = 100;
                classAttribute.@int = 115;
                classAttribute.mnd = 75;
            }
            else if (classJobCategory.SMN)
            {
                classAttribute.str = 90;
                classAttribute.dex = 100;
                classAttribute.@int = 115;
                classAttribute.mnd = 80;
            }
            else if (classJobCategory.RDM)
            {
                classAttribute.str = 55;
                classAttribute.dex = 105;
                classAttribute.@int = 115;
                classAttribute.mnd = 110;
            }

            return classAttribute;
        }

        public Attribute GetMainAttribute(ClassJobCategory classJobCategory)
        {
            var mainAttribute = GetClassAttribute(classJobCategory);

            var clanAttribute = new Attribute();
            clanAttribute.str = -1;
            clanAttribute.dex = 2;
            clanAttribute.@int = 1;
            clanAttribute.mnd = 3;

            var trait = 0;

            mainAttribute.str =
                (int) Math.Floor(Math.Floor(mainAttribute.str * 340.0d / 100.0d) + clanAttribute.str + trait);
            mainAttribute.dex =
                (int) Math.Floor(Math.Floor(mainAttribute.dex * 340.0d / 100.0d) + clanAttribute.dex + trait);
            mainAttribute.@int =
                (int) Math.Floor(Math.Floor(mainAttribute.@int * 340.0d / 100.0d) + clanAttribute.@int + trait);
            mainAttribute.mnd =
                (int) Math.Floor(Math.Floor(mainAttribute.mnd * 340.0d / 100.0d) + clanAttribute.mnd + trait);

            mainAttribute.ch = 380;
            mainAttribute.dh = 380;
            mainAttribute.det = 340;
            mainAttribute.sks = 380;
            mainAttribute.sps = 380;
            mainAttribute.ten = 380;
            mainAttribute.pie = 340;

            return mainAttribute;
        }

        public void CalculateFlatHps(int healingPotency, int healingTrait, ClassJobCategory classJobCategory)
        {
            for (var i = 0; i < gearSets.Length; i++)
            {
                var gearSet = gearSets[i];
                gearSet.CalculateFlatHps(healingPotency, healingTrait, GetClassAttribute(classJobCategory).mnd);
            }
        }

        public void CalculateFlatDps(int potency, int trait, ClassJobCategory classJobCategory)
        {
            for (var i = 0; i < gearSets.Length; i++)
            {
                var gearSet = gearSets[i];

                if (classJobCategory.IsTank || classJobCategory.IsStrDps)
                    gearSet.CalculateFlatDps(potency, trait, GetClassAttribute(classJobCategory).str, classJobCategory);
                else if (classJobCategory.IsHealer)
                    gearSet.CalculateFlatDps(potency, trait, GetClassAttribute(classJobCategory).mnd, classJobCategory);
                else if (classJobCategory.IsDexDps)
                    gearSet.CalculateFlatDps(potency, trait, GetClassAttribute(classJobCategory).dex, classJobCategory);
                else if (classJobCategory.IsIntDps)
                    gearSet.CalculateFlatDps(potency, trait, GetClassAttribute(classJobCategory).@int,
                        classJobCategory);
            }
        }
    }

    public class ColumnDefinition
    {
        public ColumnDefinition(string propertyName)
        {
            this.propertyName = propertyName;
            append = string.Empty;

            switch (propertyName)
            {
                case "dps":
                    printedName = "평균 DPS";
                    break;
                case "hps":
                    printedName = "평균 HPS";
                    break;
                case "mpRegen":
                    printedName = "틱당 MP회복";
                    break;
                case "gcd":
                    printedName = "글로벌 쿨다운";
                    append = " 초";
                    break;
                case "glGcd":
                    printedName = "질풍 글쿨";
                    append = " 초";
                    break;
                case "hutonGcd":
                    printedName = "풍둔 글쿨";
                    append = " 초";
                    break;
                case "shifuGcd":
                    printedName = "사풍 글쿨";
                    append = " 초";
                    break;
                case "rotation":
                    printedName = "로테이션 글쿨 수";
                    append = " 글쿨";
                    break;
                case "mealName":
                    printedName = "음식";
                    break;
                case "ch":
                    printedName = "극대 확률";
                    append = " %";
                    break;
                case "dh":
                    printedName = "직격 확률";
                    append = " %";
                    break;
                case "ten":
                    printedName = "불굴 추가 방어력";
                    append = " %";
                    break;
            }
        }

        public string printedName { get; set; }
        public string propertyName { get; set; }
        public string append { get; set; }
    }

    public class StatDefinition
    {
        public StatDefinition(string propertyName)
        {
            this.propertyName = propertyName;

            switch (propertyName)
            {
                case "str":
                    printedName = "힘";
                    break;
                case "dex":
                    printedName = "민첩성";
                    break;
                case "int":
                    printedName = "지능";
                    break;
                case "mnd":
                    printedName = "정신력";
                    break;
                case "ch":
                    printedName = "극대";
                    break;
                case "dh":
                    printedName = "직격";
                    break;
                case "det":
                    printedName = "의지";
                    break;
                case "sks":
                    printedName = "기시";
                    break;
                case "sps":
                    printedName = "마시";
                    break;
                case "ten":
                    printedName = "불굴";
                    break;
                case "pie":
                    printedName = "신앙";
                    break;
            }
        }

        public string printedName { get; set; }
        public string propertyName { get; set; }
    }
}