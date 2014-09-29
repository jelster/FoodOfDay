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
            var output = new List<string> { options.TimeOfDay.ToString() };
            
            Console.Write(string.Format("{0}, ", options.TimeOfDay.ToString().ToLowerInvariant()));
            var course = meal.Entree.Name.ToLowerInvariant();
             
        }
    }
}
