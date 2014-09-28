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

        private static Func<Dish, DishType[], MealTime, bool> ApplicableDishesPredicate = (dish, dishArr, mealTime) => 
            dishArr.Contains(dish.Kind) && dish.MealsAllowed.Contains(mealTime);

        protected Meal(MealTime mealTime, params DishType[] dishes)
        {
            var orderedDishes = dishes.OrderBy(x => x);
            TimeOfDay = mealTime;

             
            if (TimeOfDay == MealTime.Indeterminate)
            {
                throw new ArgumentException("Specified MealTime is invalid.");
            }
        }

        public static Meal Create(string timeOfDay, params int[] dishes)
        {
            MealTime parsed;
            Enum.TryParse<MealTime>(timeOfDay, true, out parsed);
            var safeDishes = dishes.Select(x => Enum.IsDefined(typeof(DishType), x) ? (DishType)x : DishType.Indeterminate);
            return new Meal(parsed,safeDishes.ToArray());
        }

        public static Meal Create(MealTime timeofDay, params DishType[] dishes)
        {
            return new Meal(timeofDay, dishes);
        }
    }
}
