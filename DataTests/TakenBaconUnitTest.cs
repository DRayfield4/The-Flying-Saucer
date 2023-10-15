using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the TakenBacon class
    /// </summary>
    public class TakenBaconUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Taken Bacon has 2 strips
        /// </summary>
        [Fact]
        public void DefaultCountShouldBe3Strips()
        {
            TakenBacon tb = new TakenBacon();
            Assert.Equal(2u, tb.Count);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of bacon strips</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void NameShouldAlwaysBeTakenBacon(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Taken Bacon", tb.Name);
        }

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the description does not change
        /// </summary>
        /// <param name="count">The number of bacon strips</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void DescriptionShouldAlwaysBeTheSame(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Crispy strips of bacon.", tb.Description);
        }

        /// <summary>
        /// This test verifies that a TakenBacon's count cannot exceed 6, and 
        /// if it is attempted, the count will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveSix()
        {
            TakenBacon tb = new();
            tb.Count = 7;
            Assert.Equal(6u, tb.Count);
        }

        /// <summary>
        /// This test checks the price of the TakenBacon, per strip added
        /// </summary>
        /// <param name="count">The number of strips</param>
        /// <param name="price">The price of the Taken Bacon</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            TakenBacon tb = new();
            tb.Count = count;
            Assert.Equal(price, tb.Price);
        }

        /// <summary>
        /// This test checks the calories of the TakenBacon, per strip added
        /// </summary>
        /// <param name="count">The number of strips</param>
        /// <param name="calories">The expected calories, given the specfied count</param>
        [Theory]
        [InlineData(1, 43)]
        [InlineData(2, 43 + 43)]
        [InlineData(3, 43 + 43 + 43)]
        [InlineData(4, 43 + 43 + 43 + 43)]
        [InlineData(5, 43 + 43 + 43 + 43 + 43)]
        [InlineData(6, 43 + 43 + 43 + 43 + 43 + 43)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            TakenBacon tb = new();
            tb.Count = count;
            Assert.Equal(calories, tb.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Taken Bacon
        /// </summary>
        /// <param name="count">The number of bacon strips included</param>
        /// <param name="instructions">The expected special instruction</param>
        [Theory]
        [InlineData(1, new string[] { "1 strips" })]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 strips" })]
        [InlineData(4, new string[] { "4 strips" })]
        [InlineData(5, new string[] { "5 strips" })]
        [InlineData(6, new string[] { "6 strips" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new() { Count = count };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the TakenBacon can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestTakenBaconSideItem()
        {
            TakenBacon takenBacon = new();
            Assert.IsAssignableFrom<Side>(takenBacon);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<IMenuItem>(tb);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            TakenBacon tb = new();
            string name = tb.ToString();
            Assert.Equal("Taken Bacon", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tb);
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
            TakenBacon tb = new();
            Assert.PropertyChanged(tb, propertyName, () => {
                tb.Count = count;
            });
        }
    }
}
