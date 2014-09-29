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
            return new FoodConsoleOptions() { TimeOfDay = time };
        }
    }
    public class FoodConsole
    {


        static void Main(string[] args)
        {


            var options = FoodConsoleOptions.Parse(args);

        }
    }
}
