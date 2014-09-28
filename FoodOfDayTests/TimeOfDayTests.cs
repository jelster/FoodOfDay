using System;
using NUnit.Framework;
using FoodOfDay;

namespace FoodOfDayTests
{

    public class TimeOfDayTests
    {
        [TestFixture]
        public class given_a_time_of_day
        {
            const MealTime mealTime = MealTime.Morning;
            const string MorningString = "morning";

            [TestFixture]
            public class when_a_meal_is_created
            {
                Meal sut = Meal.Create(MorningString);

                [Test]
                public void then_the_input_time_string_should_not_be_case_sensitive()
                {
                    var actual = mealTime;
                    Assert.AreEqual(sut.TimeOfDay, actual, "Input string was not parsed correctly");
                }
            }
        }
    }

    public class DishTypeTests
    {
        [TestFixture]
        public class given_a_morning
        {
            Meal sut;
            [Test]
            public void aa()
            {
                Assert.AreEqual(sut.Entree, DishType.Eggs);
            }
        }
    }
}
