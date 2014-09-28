using FoodOfDay;
using NUnit.Framework;

namespace FoodOfDayTests
{
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
                sut = Meal.Create(mealTime, DishType.Entree, DishType.Drink, DishType.Side);
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
                sut = Meal.Create(mealTime, DishType.Entree, DishType.Side, DishType.Drink, DishType.Side, DishType.Dessert);
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
