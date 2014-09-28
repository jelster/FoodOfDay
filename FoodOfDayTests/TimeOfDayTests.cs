using System;
using NUnit.Framework;
using FoodOfDay;

namespace FoodOfDayTests
{

    public class TimeOfDayTests
    {

        [TestFixture]
        public class given_a_morning
        {
            const MealTime mealTime = MealTime.Morning;
            

            [TestFixture]
            public class when_timeofday_is_specified
            {
                Meal sut;
                const string dayTimeString = "morning";

                [Test]
                public void then_input_should_not_be_case_sensitive()
                {
                    sut = Meal.Create(dayTimeString);
                    var enumSut = new Meal(MealTime.Night);
                    var actual = sut.TimeOfDay;

                    Assert.AreEqual(mealTime, actual);
                }

                [Test]
                public void aaa()
                {

                }
            }
        }
    }
}
