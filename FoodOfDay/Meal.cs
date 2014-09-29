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
    public class CourseInfo : IComparable<CourseInfo>
    {
        public int Count { get; set; }
        public Dish Dish { get; set; }

        public int CompareTo(CourseInfo other)
        {
            return Dish.Kind.CompareTo(other.Dish.Kind);
        }
        public override string ToString()
        {
            string fmt = "{0}";
            if (Count > 1) {
                return string.Format("{0}(x{1})", Dish.Name.ToLowerInvariant(), Count);
            }
            return Dish.Name.ToLowerInvariant();
            
        }
    }
    public class Meal
    {
        public Dish this[DishType d] {
            get {
                Dish dish;
                switch (d) {
                    case DishType.Entree:
                        dish = this.Entree;
                        break;
                    case DishType.Side:
                        dish = this.Side;
                        break;
                    case DishType.Drink:
                        dish = this.Drink;
                        break;
                    case DishType.Dessert:
                        dish = this.Dessert;
                        break;
                    case DishType.Indeterminate:
                        dish = Dish.Empty;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                return dish;
            }
        }
        public MealTime TimeOfDay { get; protected set; }

        public Dish Entree { get { return Dish.Entrees.FirstOrDefault(TimeFilter); } }

        public Dish Side { get { return Dish.Sides.FirstOrDefault(TimeFilter); } }
        public Dish Drink { get { return Dish.Drinks.FirstOrDefault(TimeFilter); } }
        public Dish Dessert { get { return Dish.Desserts.FirstOrDefault(TimeFilter); } }

        private readonly List<DishType> specifiedDishes = new List<DishType>();
        

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

       
        public IEnumerable<CourseInfo> GenerateMealSummary()
        {
            var groups = specifiedDishes.OrderBy(x => x).GroupBy(x => x).Select(x =>new CourseInfo { Dish = this[x.Key] ?? Dish.Empty, Count = x.Count() });
            foreach (var item in groups)
            {                
                if (TimeOfDay == MealTime.Morning && item.Dish.Kind != DishType.Drink && item.Count > 1)
                {
                    yield return item;
                    yield return new CourseInfo { Dish = Dish.Empty, Count = 1 };
                   
                    break;
                }
                if (TimeOfDay == MealTime.Night && item.Dish.Kind != DishType.Side && item.Count > 1)
                {
                    yield return item;
                    yield return new CourseInfo { Dish = Dish.Empty, Count = 1 };                

                    break;
                }
                yield return item;
            }            
        }

        private bool TimeFilter(Dish dish) { return dish.MealsAllowed.Contains(TimeOfDay); }
    }
}
