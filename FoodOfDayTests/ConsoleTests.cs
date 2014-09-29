using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FoodOfDay;

namespace FoodOfDayTests
{
    [TestFixture]
    public class ConsoleTests
    {
        [Test]
        public void CommandLineShouldParseTimeOfDay()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "morning" });
            Assert.AreEqual(MealTime.Morning, opts.TimeOfDay);

            opts = FoodConsoleOptions.Parse(new[] { "night" });
            Assert.AreEqual(MealTime.Night, opts.TimeOfDay);

        }

        [Test]
        public void CommandLineShouldParseDishes()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "morning", "1", "2", "3" });
            CollectionAssert.IsNotEmpty(opts.FoodOrder);
            Assert.IsTrue(opts.FoodOrder.First() == DishType.Entree);
            Assert.IsTrue(opts.FoodOrder.Last() == DishType.Drink);
        }

        
    }
}
