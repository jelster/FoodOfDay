using System;
using System.Collections;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FoodOfDay;


namespace FoodOfDayTests
{
    public class given_a_meal_ticket
    {
        protected Meal sut;
        protected IEnumerable<Tuple<DishType, int>> sutSummary;

        protected readonly DishType[] Breakfast = new DishType[] { DishType.Entree, DishType.Side, DishType.Drink };
        protected readonly DishType[] Dinner = new DishType[] { DishType.Entree, DishType.Side, DishType.Drink, DishType.Dessert };
        protected readonly DishType[] TiredBreakfast = new DishType[] { DishType.Entree, DishType.Side, DishType.Drink, DishType.Drink, DishType.Drink };
        protected readonly DishType[] HungryDinner = new DishType[] { DishType.Entree, DishType.Side, DishType.Side, DishType.Drink, DishType.Dessert };
        protected readonly SortedList<int, DishType> ExpectedOutputOrder = new SortedList<int, DishType>();
        protected const DishType ErrorFlag = DishType.Indeterminate;
        public given_a_meal_ticket()
        {
            ExpectedOutputOrder.Add(1, DishType.Entree);
            ExpectedOutputOrder.Add(2, DishType.Side);
            ExpectedOutputOrder.Add(3, DishType.Drink);
            ExpectedOutputOrder.Add(4, DishType.Dessert);
        }        
    }

    [TestFixture]
    public class MealTests
    {
        [TestFixture]
        public class when_breakfast_is_ordered : given_a_meal_ticket
        {
            public when_breakfast_is_ordered()
            {
                sut = Meal.Create(MealTime.Morning, Breakfast);
                sutSummary = sut.GenerateMealSummary();
            }

            [Test]
            public void then_mealtime_is_morning()
            {
                Assert.AreEqual(MealTime.Morning, sut.TimeOfDay);
            }

            [Test]
            public void then_meal_summary_is_not_empty()
            {
                Assert.IsNotEmpty(sutSummary);
            }

            [Test]
            public void then_meal_summary_is_in_proper_order()
            {
                CollectionAssert.IsOrdered(sutSummary);

            }   
        }

        [TestFixture]
        public class when_breakfast_is_ordered_after_a_long_night_coding : given_a_meal_ticket
        {
            public when_breakfast_is_ordered_after_a_long_night_coding()
            {
                sut = Meal.Create(MealTime.Morning, TiredBreakfast);
                sutSummary = sut.GenerateMealSummary();
            }

            [Test]
            public void then_there_is_enough_coffee_to_stay_awake()
            {
                Assert.AreEqual(sutSummary.First(x => x.Item1 == DishType.Drink).Item2, TiredBreakfast.Count(y => y == DishType.Drink));
            }
        }

        [TestFixture]
        public class when_dinner_is_ordered : given_a_meal_ticket
        {
            // TODO: extract base class for this and the breakfast tests
            public when_dinner_is_ordered()
            {
                sut = Meal.Create(MealTime.Night, Dinner);
                sutSummary = sut.GenerateMealSummary();
            }

            [Test]
            public void then_mealtime_is_dinner()
            {
                Assert.AreEqual(MealTime.Night, sut.TimeOfDay);
            }

            [Test]
            public void then_meal_summary_is_not_empty()
            {
                Assert.IsNotEmpty(sutSummary);
            }

            [Test]
            public void then_meal_summary_is_ordered()
            {
                CollectionAssert.IsOrdered(sutSummary);
            }
        }

        [TestFixture]
        public class when_hunger_sets_in : given_a_meal_ticket
        {
            public when_hunger_sets_in()
            {
                sut = Meal.Create(MealTime.Night, HungryDinner);
                sutSummary = sut.GenerateMealSummary();
            }

            [Test]
            public void then_enough_potatos_for_all()
            {
                Assert.AreEqual(sutSummary.First(x => x.Item1 == DishType.Side).Item2, HungryDinner.Count(y => y == DishType.Side));
            }

        }

    }
}
