using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOfDay
{
    public enum DishType
    {
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

}
