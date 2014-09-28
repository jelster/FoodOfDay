using System;
using NUnit.Framework;
using FoodOfDay;

namespace FoodOfDayTests
{
    [TestFixture]
    public class TimeOfDayTests
    {
        [TestFixture]
        public class given_a_time_of_day : given_a_morning
        {          
            const string MorningString = "morning";

            [TestFixture]
            public class when_a_meal_is_created : given_a_time_of_day
            {
                public when_a_meal_is_created() 
                {
                      sut = Meal.Create(MorningString);
                }

                [Test]
                public void then_the_input_string_should_not_be_case_sensitive()
                {
                    var actual = mealTime;
                    Assert.AreEqual(sut.TimeOfDay, actual, "Input string was not parsed correctly");
                }
            }
        }
    }


}
