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

    public enum DishType {
        Indeterminate = 0,
        Entree = 1,
        Side = 2,
        Drink = 3,
        Dessert = 4
    }

    public class Dish
    {

        public static readonly Dish Eggs = new Dish("Eggs", DishType.Entree, new[] { MealTime.Morning });
        public static readonly Dish Steak = new Dish("Steak", DishType.Entree, new[] { MealTime.Night });
        public static readonly Dish Toast = new Dish("Toast", DishType.Side, new[] { MealTime.Morning });
        public static readonly Dish Potato = new Dish("Potato", DishType.Side, new[] { MealTime.Night });

        public static readonly Dish Coffee = new Dish("Coffee", DishType.Drink, new[] { MealTime.Morning });
        public static readonly Dish Wine = new Dish("Wine", DishType.Drink, new[] { MealTime.Night });
        public static readonly Dish Cake = new Dish("Cake", DishType.Dessert, new[] { MealTime.Night });

        public static IEnumerable<Dish> Entrees { get { return new[] { Dish.Eggs, Dish.Steak }; } }
        public static IEnumerable<Dish> Sides { get { return new[] { Dish.Toast, Dish.Potato }; } }
        public static IEnumerable<Dish> Drinks { get { return new[] { Dish.Wine, Dish.Coffee }; } }
        public static IEnumerable<Dish> Desserts { get { return new[] { Dish.Cake }; } }
        
        public string Name { get; protected set; }
        public IEnumerable<MealTime> MealsAllowed { get; protected set; }

        public DishType Kind { get; set; }

        protected Dish(string name, DishType dish, IEnumerable<MealTime> times)
        {
            Name = name;
            Kind = dish;
            MealsAllowed = times ?? Enumerable.Empty<MealTime>();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Kind);
        }

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
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
