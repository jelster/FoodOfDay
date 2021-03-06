﻿using System;
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
        static Dictionary<DishType, Dish[]> Courses = new Dictionary<DishType, Dish[]>();
        static Dish()
        {
            Courses.Add(DishType.Entree, new[] { Eggs, Steak });
            Courses.Add(DishType.Side, new[] { Toast, Potato });
            Courses.Add(DishType.Drink, new[] { Coffee, Wine });
            Courses.Add(DishType.Dessert, new[] { Cake });
        }
        // TODO: this could be factored out to be populated from an arbitrary external source
        public static readonly Dish Eggs = new Dish("Eggs", DishType.Entree, new[] { MealTime.Morning });
        public static readonly Dish Steak = new Dish("Steak", DishType.Entree, new[] { MealTime.Night });
        public static readonly Dish Toast = new Dish("Toast", DishType.Side, new[] { MealTime.Morning });
        public static readonly Dish Potato = new Dish("Potato", DishType.Side, new[] { MealTime.Night });
        public static readonly Dish Coffee = new Dish("Coffee", DishType.Drink, new[] { MealTime.Morning });
        public static readonly Dish Wine = new Dish("Wine", DishType.Drink, new[] { MealTime.Night });
        public static readonly Dish Cake = new Dish("Cake", DishType.Dessert, new[] { MealTime.Night });
        public static readonly Dish Empty = new Dish("Error", DishType.Indeterminate, new[] { MealTime.Morning, MealTime.Night });

        public static IEnumerable<Dish> Entrees { get { return Courses[DishType.Entree]; } }
        public static IEnumerable<Dish> Sides { get { return Courses[DishType.Side]; } }
        public static IEnumerable<Dish> Drinks { get { return Courses[DishType.Drink]; } }
        public static IEnumerable<Dish> Desserts { get { return Courses[DishType.Dessert]; } }

        public string Name { get; protected set; }
        public IEnumerable<MealTime> MealsAllowed { get; protected set; }

        public DishType Kind { get; protected set; }

        protected Dish(string name, DishType kind, IEnumerable<MealTime> times)
        {
            Name = name;
            Kind = kind;
            MealsAllowed = times ?? Enumerable.Empty<MealTime>();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Kind);
        }

    }

}
