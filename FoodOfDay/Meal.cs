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

        public Tuple<Dish,int> Entree { get; protected set; }
        public Tuple<Dish,int> Side { get; protected set; }
        public Tuple<Dish,int> Drink { get; protected set; }
        public Tuple<Dish,int> Dessert { get; protected set; }

        private static Func<Dish, DishType[], MealTime, bool> ApplicableDishesPredicate = (dish, dishArr, mealTime) => 
            dishArr.Contains(dish.Kind) && dish.MealsAllowed.Contains(mealTime);

        protected Meal(MealTime mealTime, params DishType[] dishes)
        {
            TimeOfDay = mealTime;
            if (TimeOfDay == MealTime.Morning)
            {
                Entree = Tuple.Create(Dish.Entrees.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Morning)), 1);
                Side = Tuple.Create(Dish.Sides.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Morning)), 1);
                Drink = Tuple.Create(Dish.Drinks.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Morning)), 1);
            }
            else if (TimeOfDay == MealTime.Night)
            {
                Entree = Tuple.Create(Dish.Entrees.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night)), 1);
                Side = Tuple.Create(Dish.Sides.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night)), 1);
                Drink = Tuple.Create(Dish.Drinks.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night)), 1);
                Dessert = Tuple.Create(Dish.Desserts.FirstOrDefault(x => Meal.ApplicableDishesPredicate(x, dishes, MealTime.Night)), 1);
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
