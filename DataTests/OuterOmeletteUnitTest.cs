using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the OuterOmelette class
    /// </summary>
    public class OuterOmeletteUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with cheddar cheese
        /// </summary>
        [Fact]
        public void DefaultServedWithCheddarCheese()
        {
            OuterOmelette oo = new();
            Assert.True(oo.CheddarCheese);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with peppers
        /// </summary>
        [Fact]
        public void DefaultServedWithPeppers()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Peppers);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with mushrooms
        /// </summary>
        [Fact]
        public void DefaultServedWithMusrooms()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Mushrooms);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with tomatoes
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Tomatoes);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with onions
        /// </summary>
        [Fact]
        public void DefaultServedWithOnions()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Onions);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the OuterOmelette's state mutates, the name does not change
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, false, true)]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, false, true, false, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(false, true, true, true, false)]
        [InlineData(false, false, true, true, false)]
        public void NameShouldAlwaysBeOuterOmelette(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("Outer Omelette", oo.Name);
        }

        /// <summary>
        /// This test checks that even as the OuterOmelette's state mutates, the description does not change
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, false, true)]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, false, true, false, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(false, true, true, true, false)]
        [InlineData(false, false, true, true, false)]
        public void DescriptionAlwaysBeTheSame(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("A fully loaded Omelette.", oo.Description);
        }

        /// <summary>
        /// This test checks the price of the OuterOmelette
        /// </summary>
        /// <param name="price">The price of the OuterOmelette</param>
        [Theory]
        [InlineData(7.25)]
        public void PriceShouldBeCorrect(decimal price)
        {
            LivestockMutilation oo = new();
            Assert.Equal(price, oo.Price);
        }

        /// <summary>
        /// This test checks the calories of the OuterOmelette
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, true, true, 94 + 113 + 24 + 4 + 22 + 22)]
        [InlineData(true, false, true, true, true, 94 + 113 + 0 + 4 + 22 + 22)]
        [InlineData(true, false, false, true, true, 94 + 113 + 0 + 0 + 22 + 22)]
        [InlineData(true, true, true, true, false, 94 + 113 + 24 + 4 + 22 + 0)]
        [InlineData(true, true, true, false, false, 94 + 113 + 24 + 4 + 0 + 0)]
        [InlineData(false, true, true, true, true, 94 + 0 + 24 + 4 + 22 + 22)]
        [InlineData(false, false, true, true, true, 94 + 0 + 0 + 4 + 22 + 22)]
        [InlineData(false, false, false, false, false, 94 + 0 + 0 + 0 + 0 + 0)]
        public void CaloriesShouldBeCorrect(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, uint calories)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal(calories, oo.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omelette
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] { })]
        [InlineData(false, true, true, true, true, new string[] { "Hold Cheddar Cheese" })]
        [InlineData(true, false, true, true, true, new string[] { "Hold Peppers" })]
        [InlineData(true, true, false, true, true, new string[] { "Hold Mushrooms" })]
        [InlineData(true, true, true, false, true, new string[] { "Hold Tomatoes" })]
        [InlineData(true, true, true, true, false, new string[] { "Hold Onions" })]
        public void SpecialInstructionsRelfectsState(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, string[] instructions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, oo.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<IMenuItem>(oo);
        }

        /// <summary>
        /// Test to see if the OuterOmelette can be cast as an Entree.
        /// </summary>
        [Fact]
        public void TestOuterOmeletteEntreeItem()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<Entree>(oo);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            OuterOmelette oo = new();
            string name = oo.ToString();
            Assert.Equal("Outer Omelette", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(oo);
        }

        /// <summary>
        /// Tests that changing CheddarCheese notifys the property change
        /// </summary>
        /// <param name="chedCheese">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingCheddarCheeseShouldNotifyOfPropertyChanges(bool chedCheese, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.CheddarCheese = chedCheese;
            });
        }

        /// <summary>
        /// Tests that changing Peppers notifys the property change
        /// </summary>
        /// <param name="peppers">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingPeppersShouldNotifyOfPropertyChanges(bool peppers, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Peppers = peppers;
            });
        }

        /// <summary>
        /// Tests that changing Mushrooms notifys the property change
        /// </summary>
        /// <param name="mush">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingMushroomsShouldNotifyOfPropertyChanges(bool mush, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Mushrooms = mush;
            });
        }

        /// <summary>
        /// Tests that changing Tomatoes notifys the property change
        /// </summary>
        /// <param name="tom">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingTomatoesShouldNotifyOfPropertyChanges(bool tom, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Tomatoes = tom;
            });
        }

        /// <summary>
        /// Tests that changing Onions notifys the property change
        /// </summary>
        /// <param name="onions">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingOnionsShouldNotifyOfPropertyChanges(bool onions, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Onions = onions;
            });
        }
    }
}
