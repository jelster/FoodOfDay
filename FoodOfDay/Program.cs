using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodOfDay
{
    public class FoodConsoleOptions
    {
        public MealTime TimeOfDay { get; set; }
        public IEnumerable<DishType> FoodOrder { get; set; }

        public static FoodConsoleOptions Parse(string[] p)
        {
            MealTime time;
            Enum.TryParse(p[0], true, out time);

            return new FoodConsoleOptions()
            {
                TimeOfDay = time,
                FoodOrder = p.Skip(1)
                .Select(x =>
                    {
                        DishType d;
                        Enum.TryParse<DishType>(x, out d);
                        return d;
                    })
            };
        }
    }
    public class FoodConsole
    {
        static void Main(string[] args)
        {
            var options = FoodConsoleOptions.Parse(args);

            var meal = Meal.Create(options.TimeOfDay, options.FoodOrder.ToArray());
            var summary = meal.GenerateMealSummary();
            var outputText = GetMealOutput(summary, options);
            Console.WriteLine(outputText);
           
        }

        public static string GetMealOutput(IEnumerable<CourseInfo> mealSummary, FoodConsoleOptions options)
        {
            var output = new List<string>();
            //var timeOfDayString = string.Format("{0}, ", options.TimeOfDay.ToString().ToLowerInvariant());
            //output.Add(timeOfDayString);
            foreach (var item in mealSummary)
            {
                output.Add(item.ToString());
            }
            return string.Join(", ", output);
        }


    }
}
