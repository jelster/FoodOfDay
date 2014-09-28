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

    public class DishType
    {
        public string Name { get; protected set; }
        public IEnumerable<MealTime> MealsAllowed { get; protected set; }

        public static readonly DishType Eggs = new DishType("Eggs", new[] { MealTime.Morning });
        public static readonly DishType Steak = new DishType("Steak", new[] { MealTime.Night });
        public static readonly DishType Toast = new DishType("Toast", new[] { MealTime.Morning });
        public static readonly DishType Coffee = new DishType("Coffee", new[] { MealTime.Morning });
        public static readonly DishType Wine = new DishType("Wine", new[] { MealTime.Night });
        public static readonly DishType Cake = new DishType("Cake", new[] { MealTime.Night });
        
    }
    public class Meal
    {
        public MealTime TimeOfDay { get; protected set; }

        public DishType Entree { get; protected set; }
        public DishType Side { get; protected set; }
        public DishType Drink { get; protected set; }
        public DishType Dessert { get; protected set; }


        public Meal(MealTime mealTime)
        {
            TimeOfDay = mealTime;
        }
        protected Meal(string timeOfDay)
        {
            MealTime parsed;
            Enum.TryParse<MealTime>(timeOfDay, true, out parsed);
            TimeOfDay = parsed;            
        }

        public static Meal Create(string timeOfDay)
        {
            return new Meal(timeOfDay);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
