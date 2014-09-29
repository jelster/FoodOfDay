using System;
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
        }

        [Test]
        public void CommandLineShouldParseDishes()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "morning", "1", "2", "3" });
            CollectionAssert.IsNotEmpty(opts.FoodOrder);
        }
    }
}
