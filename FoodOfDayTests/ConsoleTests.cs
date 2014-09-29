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
        // TODO: output-based tests could be refactored into data table -driven tests


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

        [Test]
        public void ValidInputShouldOutputDishes()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "morning", "1", "2", "3" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "eggs, toast, coffee";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void InvalidMenuSelectionsOutputError()
        {

            var opts = FoodConsoleOptions.Parse(new[] { "morning", "1", "2", "3", "4" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "eggs, toast, coffee, error";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void MultipleDishesOutputCount()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "morning", "1", "2", "3", "3", "3" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "eggs, toast, coffee(x3)";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void OutOfOrderInputOutputsCorrectOrder()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "morning", "2", "1", "3" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "eggs, toast, coffee";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void FullDinnerOrderOutputsAllDishes()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "night", "1", "2", "3", "4" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "steak, potato, wine, cake";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void InvalidDinnerOutputsOnlyValidDishes()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "night", "1", "2", "3", "5" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "steak, potato, wine, error";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }


        [Test]
        public void InvalidInputStopsProcessingOutput()
        {
            var opts = FoodConsoleOptions.Parse(new[] { "night", "1", "1", "2", "3", "5" });
            var meal = Meal.Create(opts.TimeOfDay, opts.FoodOrder.ToArray());
            var output = FoodConsole.GetMealOutput(meal.GenerateMealSummary(), opts);

            const string expected = "steak, error";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
        }

        
    }
}
