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

        public Dish Entree { get; protected set; }
        public Dish Side { get; protected set; }
        public Dish Drink { get; protected set; }
        public Dish Dessert { get; protected set; }

        private static Func<Dish, DishType[], MealTime, bool> ApplicableDishesPredicate = (dish, dishArr, mealTime) => 
            dishArr.Contains(dish.Kind) && dish.MealsAllowed.Contains(mealTime);

        protected Meal(MealTime mealTime, params DishType[] dishes)
        {
            TimeOfDay = mealTime;
            if (TimeOfDay == MealTime.Morning)
            {
                Entree = Dish.Entrees.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Morning));
                Side = Dish.Sides.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Morning));
                Drink = Dish.Drinks.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Morning));
            }
            else if (TimeOfDay == MealTime.Night)
            {
                Entree = Dish.Entrees.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night));
                Side = Dish.Sides.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night));
                Drink = Dish.Drinks.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night));
                Dessert = Dish.Desserts.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night));
            }
            else
            {
                throw new ArgumentException("Specified MealTime is invalid.");
            }
        }

        public static Meal Create(string timeOfDay, params int[] dishes)
        {
            MealTime parsed;
            Enum.TryParse<MealTime>(timeOfDay, true, out parsed);

            return new Meal(parsed, dishes.Cast<DishType>().ToArray());
        }

        public static Meal Create(MealTime timeofDay, params DishType[] dishes)
        {
            return new Meal(timeofDay, dishes);
        }

    }
}
