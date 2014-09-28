using System;
using NUnit.Framework;
using FoodOfDay;

namespace FoodOfDayTests
{
    [TestFixture]
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


    public class given_a_morning
    {
        protected Meal sut;
        protected const MealTime mealTime = MealTime.Morning;
    }
    public class given_a_night
    {
        protected Meal sut;
        protected const MealTime mealTime = MealTime.Night;
    }

    [TestFixture]
    public class DishTypeTests
    {
        // TODO: test class inheritance structure could be refactored and collapsed further
        [TestFixture]
        public class when_breakfast_is_served : given_a_morning
        {
            public when_breakfast_is_served()
            {
                sut = Meal.Create(mealTime);
            }
            [Test]
            public void then_the_entree_should_be_eggs()
            {
                Assert.AreEqual(Dish.Eggs, sut.Entree);
            }

            [Test]
            public void then_the_side_should_be_toast()
            {
                Assert.AreEqual(Dish.Toast, sut.Side);
            }

            [Test]
            public void then_the_drink_should_be_coffee()
            {
                Assert.AreEqual(Dish.Coffee, sut.Drink);
            }

            [Test]
            public void then_dessert_should_be_null()
            {
                Assert.IsNull(sut.Dessert);
            }
        }


        [TestFixture]
        public class when_dinner_is_served : given_a_night
        {
            public when_dinner_is_served()
            {
                sut = Meal.Create(mealTime);
            }
            [Test]
            public void then_the_entree_should_be_steak()
            {
                Assert.AreEqual(Dish.Steak, sut.Entree);
            }

            [Test]
            public void then_the_side_should_be_potato()
            {
                Assert.AreEqual(Dish.Potato, sut.Side);
            }

            [Test]
            public void then_the_drink_should_be_wine()
            {
                Assert.AreEqual(Dish.Wine, sut.Drink);
            }

            [Test]
            public void then_dessert_should_be_cake()
            {
                Assert.AreEqual(Dish.Cake, sut.Dessert);
            }
        }

    }
}
