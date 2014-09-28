using System;
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


        protected Meal(MealTime mealTime)
        {
            TimeOfDay = mealTime;
            if (TimeOfDay == MealTime.Morning)
            {
                Entree = Dish.Entrees.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Morning));
                Side = Dish.Sides.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Morning));
                Drink = Dish.Drinks.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Morning));
            }
            else if (TimeOfDay == MealTime.Night)
            {
                Entree = Dish.Entrees.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Night));
                Side = Dish.Sides.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Night));
                Drink = Dish.Drinks.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Night));
                Dessert = Dish.Desserts.FirstOrDefault(x => x.MealsAllowed.Contains(MealTime.Night));

            }
            else
            {
                throw new ArgumentException("Specified MealTime is invalid.");
            }

        }


        public static Meal Create(string timeOfDay)
        {
            MealTime parsed;
            Enum.TryParse<MealTime>(timeOfDay, true, out parsed);

            return new Meal(parsed);
        }

        public static Meal Create(MealTime timeofDay)
        {
            return new Meal(timeofDay);
        }

    }
}
