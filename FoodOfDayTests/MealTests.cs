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
        // TODO: using Tuple hinders readability. maybe this gets wrapped?
        protected List<Tuple<DishType, int>> sutSummary;

        protected readonly DishType[] Breakfast = new DishType[] { DishType.Entree, DishType.Side, DishType.Drink };
        protected readonly DishType[] Dinner = new DishType[] { DishType.Entree, DishType.Side, DishType.Drink, DishType.Dessert };
        protected readonly DishType[] TiredBreakfast = new DishType[] { DishType.Entree, DishType.Side, DishType.Drink, DishType.Drink, DishType.Drink };
        protected readonly DishType[] HungryDinner = new DishType[] { DishType.Entree, DishType.Side, DishType.Side, DishType.Drink, DishType.Dessert };

        protected readonly DishType[] PiggyDinner = new DishType[] { DishType.Entree, DishType.Side, DishType.Side, DishType.Drink, DishType.Dessert, DishType.Dessert, DishType.Dessert };
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
                sutSummary = sut.GenerateMealSummary().ToList();
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
            public void then_meal_summary_is_ordered()
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
                sutSummary = sut.GenerateMealSummary().ToList();
            }

            [Test]
            public void then_there_is_enough_coffee_to_stay_awake()
            {
                Assert.AreEqual(sutSummary.First(x => x.Item1 == DishType.Drink).Item2, TiredBreakfast.Count(y => y == DishType.Drink));
            }

            [Test]
            public void then_there_are_no_indeterminate_dishes()
            {
                Assert.IsNull(sutSummary.FirstOrDefault(x => x.Item1 == DishType.Indeterminate));
            }
        }

        [TestFixture]
        public class when_dinner_is_ordered : given_a_meal_ticket
        {
            // TODO: extract base class for this and the breakfast tests - maybe ValidMeal?
            public when_dinner_is_ordered()
            {
                sut = Meal.Create(MealTime.Night, Dinner);
                sutSummary = sut.GenerateMealSummary().ToList();
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

            [Test]
            public void then_there_are_no_indeterminate_dishes()
            {
                Assert.IsNull(sutSummary.FirstOrDefault(x => x.Item1 == DishType.Indeterminate));
            }

        }

        [TestFixture]
        public class when_hunger_sets_in : given_a_meal_ticket
        {
            public when_hunger_sets_in()
            {
                sut = Meal.Create(MealTime.Night, HungryDinner);
                sutSummary = sut.GenerateMealSummary().ToList();
            }

            [Test]
            public void then_enough_potatos_for_all()
            {
                Assert.AreEqual(sutSummary.First(x => x.Item1 == DishType.Side).Item2, HungryDinner.Count(y => y == DishType.Side));
            }

            [Test]
            public void then_there_are_no_indeterminate_dishes()
            {
                Assert.IsNull(sutSummary.FirstOrDefault(x => x.Item1 == DishType.Indeterminate));
            }

        }

        [TestFixture]
        public class when_dinner_pigs_out : given_a_meal_ticket
        {
            // TODO: extract base test class - InvalidMeal?
            public when_dinner_pigs_out()
            {
                sut = Meal.Create(MealTime.Night, PiggyDinner);
                sutSummary = sut.GenerateMealSummary().ToList();
            }

            [Test]
            public void then_there_is_a_single_dessert_in_summary()
            {
                Assert.True(sutSummary.Count(y => y.Item1 == DishType.Dessert) == 1);
            }
            [Test]
            public void then_an_indeterminate_is_returned_after_the_first_dessert()
            {
                var indeterminateDish = sutSummary.SingleOrDefault(x => x.Item1 == DishType.Indeterminate);
                Assert.IsNotNull(indeterminateDish);
                var dessert = sutSummary.SingleOrDefault(x => x.Item1 == DishType.Dessert);

                var indyIdx = sutSummary.IndexOf(indeterminateDish);
                var desIdx = sutSummary.IndexOf(dessert);

                Assert.AreEqual(desIdx, indyIdx - 1);
                


            }
        }

    }
}
