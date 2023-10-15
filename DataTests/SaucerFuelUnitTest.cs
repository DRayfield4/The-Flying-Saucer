using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Saucer Fuel class
    /// </summary>
    public class SaucerFuelUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered saucer Fuel is served with cream
        /// </summary>
        [Fact]
        public void DefaultServedWithCream()
        {
            SaucerFuel sf = new();
            Assert.False(sf.Cream);
        }

        /// <summary>
        /// Checks that an unaltered saucer Fuel is served as a decaf
        /// </summary>
        [Fact]
        public void DefaultServedDecaf()
        {
            SaucerFuel sf = new();
            Assert.False(sf.Decaf);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the name does not change
        /// </summary>
        /// <param name="cream">If it comes cream</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldReflectState(bool cream)
        {
            SaucerFuel sf = new()
            {
                Cream = cream
            };
            Assert.Equal("Saucer Fuel", sf.Name);
        }

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the name does not change
        /// </summary>
        /// <param name="decaf">If it is decaf</param>
        [Theory]
        [InlineData(true)]
        public void NameShouldReflectDecafState(bool decaf)
        {
            SaucerFuel sf = new()
            {
                Decaf = decaf
            };
            Assert.Equal("Decaf Saucer Fuel", sf.Name);
        }

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the description does not change
        /// </summary>
        /// <param name="cream">If it comes with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionShouldAlwaysBeSaucerFuel(bool cream)
        {
            SaucerFuel sf = new() { Cream = cream };
            Assert.Equal("A steaming cup of coffee.", sf.Description);
        }

        /// <summary>
        /// Tests the cream property
        /// </summary>
        /// <param name="cream">If it comes with cream</param>
        [Fact]
        public void Cream()
        {
            SaucerFuel sf = new();
            sf.Cream = true;

            Assert.True(sf.Cream);
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
            SaucerFuel sf = new();
            sf.Size = size;

            decimal actualPrice = sf.Price;

            Assert.Equal(price, actualPrice);
        }

        /// <summary>
        /// Tests the correct calories depending on size
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="cream">if it has cream</param>
        /// <param name="cal">The calories for the size</param>
        [Theory]
        [InlineData(ServingSize.Small, false, 1u)]
        [InlineData(ServingSize.Small, true, 30u)]
        [InlineData(ServingSize.Medium, false, 2u)]
        [InlineData(ServingSize.Medium, true, 31u)]
        [InlineData(ServingSize.Large, false, 3u)]
        [InlineData(ServingSize.Large, true, 32u)]
        public void CorrectCalories(ServingSize size, bool cream, uint cal)
        {
            SaucerFuel sf = new()
            {
                Size = size,
                Cream = cream
            };

            uint actualCalories = sf.Calories;

            Assert.Equal(cal, actualCalories);
        }

        /// <summary>
        /// Checks that the special instuctions reflect the state
        /// </summary>
        /// <param name="cream">If it has ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(false, new string[] { })]
        [InlineData(true, new string[] { "With Cream" })]
        public void SpecialInstructionsReflectsState(bool cream, string[] instructions)
        {
            SaucerFuel sf = new() { Cream = cream };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sf.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, sf.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the SaucerFuel can be cast as a Drink.
        /// </summary>
        [Fact]
        public void TestSFDrinkItem()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<Drink>(sf);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<IMenuItem>(sf);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            SaucerFuel sf = new();
            string name = sf.ToString();
            Assert.Equal("Saucer Fuel", name);
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
            SaucerFuel saucerFuel = new();
            Assert.PropertyChanged(saucerFuel, propertyName, () => {
                saucerFuel.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing Decaf notifys the property change
        /// </summary>
        /// <param name="decaf">If it's decaf</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Name")]
        public void ChangingDecafShouldNotifyOfPropertyChanges(bool decaf, string propertyName)
        {
            SaucerFuel sf = new();
            Assert.PropertyChanged(sf, propertyName, () =>
            {
                sf.Decaf = decaf;
            });
        }

        /// <summary>
        /// Tests that changing Cream notifys the property change
        /// </summary>
        /// <param name="cream">If it has cream</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(true, "SpecialInstructions")]
        public void ChangingCreamShouldNotifyOfPropertyChanges(bool cream, string propertyName)
        {
            SaucerFuel sf = new();
            Assert.PropertyChanged(sf, propertyName, () =>
            {
                sf.Cream = cream;
            });
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            SaucerFuel saucerFuel = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(saucerFuel);
        }
    }
}
