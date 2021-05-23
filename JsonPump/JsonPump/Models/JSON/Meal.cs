using System;

namespace JsonPump.Models.JSON
{
    public class Meal
    {
        public Meal(string mealName)
        {
            Console.WriteLine($"\t=> Loading Meal {mealName}");

            var meal = Program.Meals[Program.MealNameMapper[mealName]];

            nameEn = meal.NameEn;
            nameKo = string.IsNullOrEmpty(meal.NameKo) ? null : meal.NameKo;
            iconSrc = Utility.GetImage(meal);

            mealAttribute = new MealAttribute();

            foreach (var paramKey in meal.Parameters.Keys)
            {
                var foodValue = meal.Parameters[paramKey];
                var mealValue = new MealValue(foodValue);

                switch (paramKey)
                {
                    case "Critical Hit":
                        mealAttribute.ch = mealValue;
                        break;
                    case "Direct Hit Rate":
                        mealAttribute.dh = mealValue;
                        break;
                    case "Determination":
                        mealAttribute.det = mealValue;
                        break;
                    case "Skill Speed":
                        mealAttribute.sks = mealValue;
                        break;
                    case "Spell Speed":
                        mealAttribute.sps = mealValue;
                        break;
                    case "Tenacity":
                        mealAttribute.ten = mealValue;
                        break;
                    case "Piety":
                        mealAttribute.pie = mealValue;
                        break;
                }
            }
        }

        public string nameEn { get; set; }
        public string nameKo { get; set; }
        public string iconSrc { get; set; }
        public MealAttribute mealAttribute { get; set; }
    }

    public class MealAttribute
    {
        public MealValue ch { get; set; }
        public MealValue dh { get; set; }
        public MealValue det { get; set; }
        public MealValue sks { get; set; }
        public MealValue sps { get; set; }
        public MealValue ten { get; set; }
        public MealValue pie { get; set; }
    }

    public class MealValue
    {
        public MealValue(ItemFoodValue foodValue)
        {
            value = foodValue.Value;
            max = foodValue.Max;
        }

        public int value { get; set; }
        public int max { get; set; }
    }
}