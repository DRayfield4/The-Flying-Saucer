using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit Tests for the InorganicSubstance class
    /// </summary>
    public class InorganicSubstanceUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Inorganic Substance is served with ice
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            InorganicSubstance sub = new();
            Assert.True(sub.Ice);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the InorganicSubstance's state mutates, the name does not change
        /// </summary>
        /// <param name="ice">If it comes with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeInorganicSubstance(bool ice)
        {
            InorganicSubstance sub = new() { Ice = ice };
            Assert.Equal("Inorganic Substance", sub.Name);
        }

        /// <summary>
        /// This test checks that even as the Inorganic Substance's state mutates, the description does not change
        /// </summary>
        /// <param name="ice">If it comes with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionShouldAlwaysBeSame(bool ice)
        {
            InorganicSubstance sub = new() { Ice = ice};
            Assert.Equal("A cold glass of ice water.", sub.Description);
        }

        /// <summary>
        /// Tests the ice property
        /// </summary>
        /// <param name="ice">If it comes with ice</param>
        [Fact]
        public void NoIce()
        {
            InorganicSubstance sub = new();
            sub.Ice = false;

            Assert.False(sub.Ice);
        }

        /// <summary>
        /// Test all the correct prices depending on size
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="price">Price</param>
        [Theory]
        [InlineData(ServingSize.Small, 0)]
        [InlineData(ServingSize.Medium, 0)]
        [InlineData(ServingSize.Large, 0)]
        public void CorrectPrices(ServingSize size, decimal price)
        {
            InorganicSubstance sub = new();
            sub.Size = size;

            decimal actualPrice = sub.Price;

            Assert.Equal(price, actualPrice);
        }

        /// <summary>
        /// Test all the correct calories depending on size
        /// </summary>
        /// <param name="size">Size of the drink</param>
        /// <param name="cal">The calories</param>
        [Theory]
        [InlineData(ServingSize.Small, 0)]
        [InlineData(ServingSize.Medium, 0)]
        [InlineData(ServingSize.Large, 0)]
        public void CorrectCalories(ServingSize size, uint cal)
        {
            InorganicSubstance sub = new();
            sub.Size = size;

            Assert.Equal(cal, sub.Calories);
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
            InorganicSubstance sub = new()
            {
                Ice = ice
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sub.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, sub.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the Inorganic Vegetation can be cast as a Drink.
        /// </summary>
        [Fact]
        public void TestISDrinkItem()
        {
            InorganicSubstance sub = new();
            Assert.IsAssignableFrom<Drink>(sub);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            InorganicSubstance sub = new();
            Assert.IsAssignableFrom<IMenuItem>(sub);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            InorganicSubstance sub = new();
            string name = sub.ToString();
            Assert.Equal("Inorganic Substance", name);
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
            InorganicSubstance inS = new();
            Assert.PropertyChanged(inS, propertyName, () =>
            {
                inS.Ice = ice;
            });
        }

        /// <summary>
        /// Tests that InorganicSubstance implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            InorganicSubstance inS = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(inS);
        }
    }
}
