using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FoodOfDay;

namespace FoodOfDayTests
{
    public class given_a_time_of_day : given_a_morning
    {
        protected const string MorningString = "morning";
    }

    [TestFixture]
    public class TimeOfDayTests
    {

        [TestFixture]
        public class when_a_meal_is_created : given_a_time_of_day
        {
            protected readonly List<DishType> MealOrder = new List<DishType> { DishType.Entree, DishType.Dessert, DishType.Side, DishType.Side };
            public when_a_meal_is_created()
            {
                sut = Meal.Create(MorningString, MealOrder.Cast<int>().ToArray());
            }

            [Test]
            public void then_the_input_string_should_not_be_case_sensitive()
            {
                Assert.AreEqual(MealTime.Morning, sut.TimeOfDay, "Input string was not parsed correctly");
            }            
        }
    }



}
