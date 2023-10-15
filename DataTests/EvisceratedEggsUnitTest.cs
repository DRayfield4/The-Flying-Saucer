using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the EvisceratedEggs class
    /// </summary>
    public class EvisceratedEggsUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs is served over easy
        /// </summary>
        [Fact]
        public void DefaultStyleShouldBeOverEasy()
        {
            EvisceratedEggs ee = new EvisceratedEggs();
            Assert.Equal(EggStyle.OverEasy, ee.Style);
        }

        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs has 2 eggs
        /// </summary>
        [Fact]
        public void DefaultCountShouldBe2Eggs()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(2u, ee.Count);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="style">The style of eggs</param>
        [Theory]
        [InlineData(2, EggStyle.OverEasy)]
        [InlineData(6, EggStyle.OverEasy)]
        [InlineData(2, EggStyle.Scrambled)]
        [InlineData(4, EggStyle.SunnySideUp)]
        [InlineData(3, EggStyle.HardBoiled)]
        [InlineData(3, EggStyle.Poached)]
        [InlineData(5, EggStyle.HardBoiled)]
        [InlineData(2, EggStyle.Poached)]
        public void NameShouldAlwaysBeEvisceratedEggs(uint count, EggStyle style)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style
            };
            Assert.Equal("Eviscerated Eggs", ee.Name);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the description does not change
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="style">The style of eggs</param>
        [Theory]
        [InlineData(2, EggStyle.OverEasy)]
        [InlineData(6, EggStyle.OverEasy)]
        [InlineData(2, EggStyle.Scrambled)]
        [InlineData(4, EggStyle.SunnySideUp)]
        [InlineData(3, EggStyle.HardBoiled)]
        [InlineData(3, EggStyle.Poached)]
        [InlineData(5, EggStyle.HardBoiled)]
        [InlineData(2, EggStyle.Poached)]
        public void DescriptionShouldAlwaysBeTheSame(uint count, EggStyle style)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style
            };
            Assert.Equal("Eggs prepared the way you like.", ee.Description);
        }

        /// <summary>
        /// This tests that the count should be between 1 and 6
        /// </summary>
        /// <param name="count">The actual count</param>
        /// <param name="expected">The expected count</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(8, 6)]
        [InlineData(9, 6)]
        public void CountShouldBeBetweenOneAndSix(uint count, uint expected)
        {
            EvisceratedEggs ee = new();
            ee.Count = count;
            Assert.Equal(expected, ee.Count);
        }

        /// <summary>
        /// This test checks the price of the EvisceratedEggs, per egg added
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="price">The price of the Eviscerated Eggs</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            EvisceratedEggs ee = new();
            ee.Count = count;
            Assert.Equal(price, ee.Price);
        }

        /// <summary>
        /// This test checks the calories of the EvisceratedEggs, per egg added
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="calories">The expected calories, given the specfied count</param>
        [Theory]
        [InlineData(1, 78)]
        [InlineData(2, 78 + 78)]
        [InlineData(3, 78 + 78 + 78)]
        [InlineData(4, 78 + 78 + 78 + 78)]
        [InlineData(5, 78 + 78 + 78 + 78 + 78)]
        [InlineData(6, 78 + 78 + 78 + 78 + 78 + 78)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs ee = new();
            ee.Count = count;
            Assert.Equal(calories, ee.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Eviscerated Eggs
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">The style of the eggs included</param>
        /// <param name="instructions">The expected special instruction</param>
        [Theory]
        [InlineData(2, EggStyle.OverEasy, new string[] { "Over Easy" })]
        [InlineData(3, EggStyle.OverEasy, new string[] { "3 eggs", "Over Easy" })]
        [InlineData(4, EggStyle.HardBoiled, new string[] { "4 eggs", "Hard Boiled" })]
        [InlineData(5, EggStyle.SunnySideUp, new string[] { "5 eggs", "Sunny Side Up" })]
        [InlineData(6, EggStyle.Poached, new string[] { "6 eggs", "Poached" })]
        public void SpecialInstructionsRelfectsState(uint count, EggStyle style, string[] instructions)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ee.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the EvisceratedEggs can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestEvisceratedEggsSideItem()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<Side>(ee);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<IMenuItem>(ee);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            EvisceratedEggs ee = new();
            string name = ee.ToString();
            Assert.Equal("Eviscerated Eggs", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ee);
        }

        /// <summary>
        /// Tests that changing the count notifys the property change
        /// </summary>
        /// <param name="count">The size being passed in</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(1, "SpecialInstructions")]
        [InlineData(4, "SpecialInstructions")]
        [InlineData(6, "SpecialInstructions")]
        [InlineData(1, "Price")]
        [InlineData(2, "Price")]
        [InlineData(6, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(2, "Calories")]
        [InlineData(6, "Calories")]
        public void ChangingCountShouldNotifyOfPropertyChanges(uint count, string propertyName)
        {
            EvisceratedEggs ee = new();
            Assert.PropertyChanged(ee, propertyName, () => {
                ee.Count = count;
            });
        }

        /// <summary>
        /// Tests that changing EggStyle notifys the property change
        /// </summary>
        /// <param name="style">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(EggStyle.SoftBoiled, "SpecialInstructions")]
        [InlineData(EggStyle.HardBoiled, "SpecialInstructions")]
        [InlineData(EggStyle.Scrambled, "SpecialInstructions")]
        [InlineData(EggStyle.Poached, "SpecialInstructions")]
        [InlineData(EggStyle.SunnySideUp, "SpecialInstructions")]
        [InlineData(EggStyle.OverEasy, "SpecialInstructions")]
        public void ChangingEggStyleShouldNotifyOfPropertyChanges(EggStyle style, string propertyName)
        {
            EvisceratedEggs ee = new();
            Assert.PropertyChanged(ee, propertyName, () =>
            {
                ee.Style = style;
            });
        }
    }
}
