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
    }
}
