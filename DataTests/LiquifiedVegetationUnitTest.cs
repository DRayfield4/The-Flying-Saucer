using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Liquified Vegetation class
    /// </summary>
    public class LiquifiedVegetationUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Liquified Vegetation is served with ice
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            LiquifiedVegetation lv = new();
            Assert.True(lv.Ice);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the LiquifiedVegetation's state mutates, the name does not change
        /// </summary>
        /// <param name="ice">If it comes with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeLiquifiedVegetation(bool ice)
        {
            LiquifiedVegetation lv = new() { Ice = ice };
            Assert.Equal("Liquified Vegetation", lv.Name);
        }

        /// <summary>
        /// This test checks that even as the LiquifiedVegetation's state mutates, the description does not change
        /// </summary>
        /// <param name="ice">If it comes with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionShouldAlwaysBeLiquifiedVegetation(bool ice)
        {
            LiquifiedVegetation lv = new() { Ice = ice };
            Assert.Equal("A cold glass of blended vegetable juice.", lv.Description);
        }

        /// <summary>
        /// Tests the ice property
        /// </summary>
        /// <param name="ice">If it comes with ice</param>
        [Fact]
        public void NoIce()
        {
            LiquifiedVegetation lv = new();
            lv.Ice = false;

            Assert.False(lv.Ice);
        }

        /// <summary>
        /// Test all the correct prices depending on size
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void CorrectPrices(ServingSize size, decimal price)
        {
            LiquifiedVegetation lv = new();
            lv.Size = size;

            decimal actualPrice = lv.Price;

            Assert.Equal(price, actualPrice);
        }

        /// <summary>
        /// Tests the correct calories depending on size
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="cal">The calories for the size</param>
        [Theory]
        [InlineData(ServingSize.Small, 72u)]
        [InlineData(ServingSize.Medium, 144u)]
        [InlineData(ServingSize.Large, 216u)]
        public void CorrectCalories(ServingSize size, uint cal)
        {
            LiquifiedVegetation lv = new();
            lv.Size = size;

            uint actualCalories = lv.Calories;

            Assert.Equal(cal, actualCalories);
        }

        /// <summary>
        /// Checks that the special instuctions reflect the state
        /// </summary>
        /// <param name="ice">If it has ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void SpecialInstructionsReflectsState(bool ice, string[] instructions)
        {
            LiquifiedVegetation lv = new()
            {
                Ice = ice
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lv.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lv.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the Liquified Vegetation can be cast as a Drink.
        /// </summary>
        [Fact]
        public void TestLVDrinkItem()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<Drink>(lv);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<IMenuItem>(lv);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            LiquifiedVegetation lv = new();
            string name = lv.ToString();
            Assert.Equal("Liquified Vegetation", name);
        }

        /// <summary>
        /// Tests that changing the size notifys the property change
        /// </summary>
        /// <param name="size">The size being passed in</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        //[InlineData(ServingSize.Small, "Size")]
        //[InlineData(ServingSize.Medium, "Size")]
        //[InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Small, "Price")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Small, "Calories")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Large, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            LiquifiedVegetation lv = new();
            Assert.PropertyChanged(lv, propertyName, () => {
                lv.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing Ice notifys the property change
        /// </summary>
        /// <param name="ice">If it's decaf</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingIceShouldNotifyOfPropertyChanges(bool ice, string propertyName)
        {
            LiquifiedVegetation lv = new();
            Assert.PropertyChanged(lv, propertyName, () =>
            {
                lv.Ice = ice;
            });
        }

        /// <summary>
        /// Tests that InorganicSubstance implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lv);
        }
    }
}
