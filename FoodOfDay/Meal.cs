using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOfDay
{
    public enum MealTime
    {
        Indeterminate = 0,
        Morning = 1,
        Night = 2
    }
    public class Meal
    {
        public MealTime TimeOfDay { get; protected set; }

        public Dish Entree { get { return Dish.Entrees.FirstOrDefault(x => x.MealsAllowed.Contains(TimeOfDay)); }}
        public Dish Side { get { return Dish.Sides.FirstOrDefault(x => x.MealsAllowed.Contains(TimeOfDay)); } }
        public Dish Drink { get { return Dish.Drinks.FirstOrDefault(x => x.MealsAllowed.Contains(TimeOfDay)); } }
        public Dish Dessert { get { return Dish.Desserts.FirstOrDefault(x => x.MealsAllowed.Contains(TimeOfDay)); } }

        private readonly List<DishType> specifiedDishes = new List<DishType>();


        private static Func<Dish, DishType[], MealTime, bool> ApplicableDishesPredicate = (dish, dishArr, mealTime) => 
            dishArr.Contains(dish.Kind) && dish.MealsAllowed.Contains(mealTime);

        protected Meal(MealTime mealTime, params DishType[] dishes)
        {
            TimeOfDay = mealTime;
            specifiedDishes.AddRange(dishes);
        }

        public static Meal Create(string timeOfDay, params int[] dishes)
        {
            MealTime parsed;
            var parseSuccessful = Enum.TryParse<MealTime>(timeOfDay, true, out parsed);
            if (!parseSuccessful || parsed == MealTime.Indeterminate)
            {
                parsed = MealTime.Morning; // Everyone deserves to have breakfast at any time of the day... sometimes 2x

            }
            var safeDishes = dishes.Select(x => Enum.IsDefined(typeof(DishType), x) ? (DishType)x : DishType.Indeterminate).ToArray();
            return Meal.Create(parsed, safeDishes);
        }

        public static Meal Create(MealTime timeOfDay, params DishType[] dishes)
        {
            if (timeOfDay == MealTime.Indeterminate)
            {
                timeOfDay = MealTime.Morning;
            }
            return new Meal(timeOfDay, dishes ?? new[] { DishType.Entree, DishType.Side, DishType.Drink, DishType.Dessert });
        }

        public IEnumerable<Tuple<DishType, int>> GenerateMealSummary()
        {
            var dishes = specifiedDishes.ToList();
            return specifiedDishes.Distinct().Select(x => Tuple.Create<DishType, int>(x, dishes.Count(d => d == x)));
        }
    }
}
