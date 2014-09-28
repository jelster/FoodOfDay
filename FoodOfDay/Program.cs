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
