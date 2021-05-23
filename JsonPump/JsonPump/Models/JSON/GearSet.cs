using System;

namespace JsonPump.Models.JSON
{
    public class GearSet
    {
        private static readonly int main = 340;
        private static readonly int sub = 380;
        private static readonly int div = 3300;

        private static readonly int _70main = 292;
        private static readonly int _70sub = 364;
        private static readonly int _70div = 2170;

        public GearSet(string title, string description, string mealName, double dps, params Gear[] gears)
        {
            attribute = null;
            gcd = 0d;

            this.title = title;
            this.description = description;

            meal = new Meal(mealName);
            this.mealName = string.IsNullOrEmpty(meal.nameKo) ? meal.nameEn : meal.nameKo;

            this.dps = dps;
            this.gears = gears;
        }

        public string title { get; set; }
        public string description { get; set; }
        public Attribute attribute { get; set; }
        public double dps { get; set; }
        public double hps { get; set; }
        public int mpRegen { get; set; }
        public double gcd { get; set; }
        public double glGcd { get; set; }
        public double hutonGcd { get; set; }
        public double shifuGcd { get; set; }
        public int rotation { get; set; }
        public string mealName { get; set; }
        public Meal meal { get; set; }
        public double ch { get; set; }
        public double dh { get; set; }
        public double ten { get; set; }
        public Gear[] gears { get; set; }

        public Attribute GetTotalAttribute()
        {
            var totalAttribute = new Attribute();

            foreach (var gear in gears) totalAttribute.Add(gear.GetTotalAttribute());

            return totalAttribute;
        }

        public void Calculate(ClassJobCategory classJobCategory)
        {
            mpRegen = (int) Math.Floor((attribute.pie - main) * 150.0d / div) + 200;

            var speedFactor = classJobCategory.IsHealer || classJobCategory.IsIntDps ? attribute.sps : attribute.sks;
            var rawGcd = (int) Math.Floor((2000 - (int) Math.Floor((speedFactor - sub) * 130.0d / div + 1000.0d)) *
                2500.0d / 1000.0d);
            gcd = (int) Math.Floor(rawGcd / 10.0d) / 100.0d;

            var glRawGcd = (int) Math.Floor(rawGcd * (100 - 20) / 100.0d);
            glGcd = (int) Math.Floor(glRawGcd / 10.0d) / 100.0d;

            var hutonRawGcd = (int) Math.Floor(rawGcd * (100 - 15) / 100.0d);
            hutonGcd = (int) Math.Floor(hutonRawGcd / 10.0d) / 100.0d;

            var shifuRawGcd = (int) Math.Floor(rawGcd * (100 - 13) / 100.0d);
            shifuGcd = (int) Math.Floor(shifuRawGcd / 10.0d) / 100.0d;

            ch = (int) Math.Floor((attribute.ch - sub) * 200.0d / div + 50.0d) / 10.0d;
            dh = (int) Math.Floor((attribute.dh - sub) * 550.0d / div) / 10.0d;

            ten = (int) Math.Floor((attribute.ten - sub) * 100.0d / div) / 10.0d;
        }

        public void Calculate70(ClassJobCategory classJobCategory)
        {
            mpRegen = (int) Math.Floor((attribute.pie - _70main) * 150.0d / _70div) + 200;

            var speedFactor = classJobCategory.IsHealer || classJobCategory.IsIntDps ? attribute.sps : attribute.sks;
            var rawGcd =
                (int) Math.Floor((2000 - (int) Math.Floor((speedFactor - _70sub) * 130.0d / _70div + 1000.0d)) *
                    2500.0d / 1000.0d);
            gcd = (int) Math.Floor(rawGcd / 10.0d) / 100.0d;

            var glRawGcd = (int) Math.Floor(rawGcd * (100 - 20) / 100.0d);
            glGcd = (int) Math.Floor(glRawGcd / 10.0d) / 100.0d;

            var hutonRawGcd = (int) Math.Floor(rawGcd * (100 - 15) / 100.0d);
            hutonGcd = (int) Math.Floor(hutonRawGcd / 10.0d) / 100.0d;

            var shifuRawGcd = (int) Math.Floor(rawGcd * (100 - 13) / 100.0d);
            shifuGcd = (int) Math.Floor(shifuRawGcd / 10.0d) / 100.0d;

            ch = (int) Math.Floor((attribute.ch - _70sub) * 200.0d / _70div + 50.0d) / 10.0d;
            dh = (int) Math.Floor((attribute.dh - _70sub) * 550.0d / _70div) / 10.0d;

            ten = (int) Math.Floor((attribute.ten - _70sub) * 100.0d / _70div) / 10.0d;
        }

        public void CalculateFlatHps(int healingPotency, int healingTrait, int mindModifier)
        {
            var fDet = (int) Math.Floor((attribute.det - main) * 130.0d / div + 1000.0d);
            var fWd = (int) Math.Floor(main * mindModifier / 1000.0d + attribute.wd);
            var fCrit = (int) Math.Floor((attribute.ch - sub) * 200.0d / div + 1400.0d);

            var fHmp = (int) Math.Floor((attribute.mnd - 340) * 100.0d / 304.0d) + 100;
            var h1 = (int) Math.Floor(Math.Floor(healingPotency * fHmp * fDet / 100.0d) / 1000.0d);
            var h2 = (int) Math.Floor(Math.Floor(h1 * fWd / 100.0d) * (healingTrait + 100) / 100.0d);
            var h3ch = (int) Math.Floor(h2 * fCrit / 1000.0d);

            var healing = h3ch * ch / 100.0d + h2 * (100 - ch) / 100.0d;

            hps = Math.Floor(healing / gcd * 100.0d) / 100.0d;
        }

        public void Calculate70Hps(int healingPotency, int healingTrait, int mindModifier)
        {
            var fDet = (int) Math.Floor((attribute.det - _70main) * 130.0d / _70div + 1000.0d);
            var fWd = (int) Math.Floor(_70main * mindModifier / 1000.0d + attribute.wd);
            var fCrit = (int) Math.Floor((attribute.ch - _70sub) * 200.0d / _70div + 1400.0d);

            var fHmp = (int) Math.Floor((attribute.mnd - 340) * 100.0d / 304.0d) + 100;
            var h1 = (int) Math.Floor(Math.Floor(healingPotency * fHmp * fDet / 100.0d) / 1000.0d);
            var h2 = (int) Math.Floor(Math.Floor(h1 * fWd / 100.0d) * (healingTrait + 100) / 100.0d);
            var h3ch = (int) Math.Floor(h2 * fCrit / 1000.0d);

            var healing = h3ch * ch / 100.0d + h2 * (100 - ch) / 100.0d;

            hps = Math.Floor(healing / gcd * 100.0d) / 100.0d;
        }

        public void CalculateFlatDps(long potency, long trait, long mainModifier, ClassJobCategory classJobCategory)
        {
            var mainAttribute = 0;

            if (classJobCategory.IsTank || classJobCategory.IsStrDps)
                mainAttribute = attribute.str;
            else if (classJobCategory.IsHealer)
                mainAttribute = attribute.mnd;
            else if (classJobCategory.IsDexDps)
                mainAttribute = attribute.dex;
            else if (classJobCategory.IsIntDps) mainAttribute = attribute.@int;

            var fDet = (int) Math.Floor((attribute.det - main) * 130.0d / div + 1000.0d);
            var fWd = (int) Math.Floor(main * mainModifier / 1000.0d + attribute.wd);
            var fCrit = (int) Math.Floor((attribute.ch - sub) * 200.0d / div + 1400.0d);

            var fAttack = (int) Math.Floor((mainAttribute - 340) * 165.0d / 340.0d) + 100;
            var d1 = (int) Math.Floor(Math.Floor(potency * fAttack * fDet / 100.0d) / 1000.0d);
            var d2 = (int) Math.Floor(Math.Floor(d1 * fWd / 100.0d) * (trait + 100) / 100.0d);

            var d3chdh = (int) Math.Floor(Math.Floor(d2 * fCrit / 1000.0d) * 125.0d / 100.0d);
            var d3ch = (int) Math.Floor(d2 * fCrit / 1000.0d);
            var d3dh = (int) Math.Floor(d2 * 125.0d / 100.0d);

            var chdhChance = ch / 100.0d * dh / 100.0d;
            var chChance = ch / 100.0d - chdhChance;
            var dhChance = dh / 100.0d - chdhChance;
            var noneChance = 1 - chdhChance - chChance - dhChance;
            var damage = d3chdh * chdhChance + d3ch * chChance + d3dh * dhChance + d2 * noneChance;

            dps = (int) Math.Floor(damage / gcd * 100.0d) / 100.0d;
        }
    }
}