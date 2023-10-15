using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the LivestockMutilation class
    /// </summary>
    public class LivestockMutilationUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Livestock Mutilation has 3 biscuits
        /// </summary>
        [Fact]
        public void DefaultBiscuitsShouldBe3Biscuits()
        {
            LivestockMutilation lm = new();
            Assert.Equal(3u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that an unaltered Livestock Mutilation is served with gravy
        /// </summary>
        [Fact]
        public void DefaultServedWithGravy()
        {
            LivestockMutilation lm = new();
            Assert.True(lm.Gravy);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the name does not change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        [Theory]
        [InlineData(0, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, true)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        public void NameShouldAlwaysBeLivestockMutilation(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the description does not change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        [Theory]
        [InlineData(0, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, true)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        public void DescriptionShouldAlwaysBeTheSame(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal("A hearty serving of biscuits, smothered in sausage-laden gravy.", lm.Description);
        }

        /// <summary>
        /// This test verifies that a LivestockMutilation's biscuit count cannot exceed 8, and 
        /// if it is attempted, the count will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveEight()
        {
            LivestockMutilation lm = new();
            lm.Biscuits = 9;
            Assert.Equal(8u, lm.Biscuits);
        }

        /// <summary>
        /// This test checks the price of the LivestockMutilation, per biscuit added
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="price">The price of the LivestockMutilation</param>
        [Theory]
        [InlineData(3, 7.25)]
        [InlineData(4, 7.25 + 1)]
        [InlineData(5, 7.25 + 1 + 1)]
        [InlineData(6, 7.25 + 1 + 1 + 1)]
        [InlineData(7, 7.25 + 1 + 1 + 1 + 1)]
        [InlineData(8, 7.25 + 1 + 1 + 1 + 1 + 1)]
        public void PriceShouldBeCorrect(uint biscuits, decimal price)
        {
            LivestockMutilation lm = new();
            lm.Biscuits = biscuits;
            Assert.Equal(price, lm.Price);
        }

        /// <summary>
        /// This test checks the calories of the LivestockMutilation, per biscuit added
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(3, true, 49 * 3 + 140)]
        [InlineData(4, true, 49 * 4 + 140)]
        [InlineData(4, false, 49 * 4 + 0)]
        [InlineData(8, true, 49 * 8 + 140)]
        [InlineData(7, true, 49 * 7 + 140)]
        [InlineData(6, false, 49 * 6 + 0)]
        [InlineData(5, false, 49 * 5 + 0)]
        [InlineData(0, true, 49 * 0 + 140)]
        public void CaloriesShouldBeCorrect(uint biscuits, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal(calories, lm.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Livestock Mutilation
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(3, true, new string[] { })]
        [InlineData(6, true, new string[] { "6 biscuits" })]
        [InlineData(3, false, new string[] { "Hold gravy" })]
        public void SpecialInstructionsRelfectsState(uint biscuits, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<IMenuItem>(lm);
        }

        /// <summary>
        /// Test to see if the Livestock Mutilation can be cast as an Entree.
        /// </summary>
        [Fact]
        public void TestLivestockMutilationEntreeItem()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<Entree>(lm);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            LivestockMutilation lm = new();
            string name = lm.ToString();
            Assert.Equal("Livestock Mutilation", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lm);
        }

        /// <summary>
        /// Tests that changing the biscuits notifys the property change
        /// </summary>
        /// <param name="biscuits">The size being passed in</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(4, "SpecialInstructions")]
        [InlineData(2, "SpecialInstructions")]
        [InlineData(8, "SpecialInstructions")]
        [InlineData(2, "Price")]
        [InlineData(3, "Price")]
        [InlineData(8, "Price")]
        [InlineData(2, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(8, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint biscuits, string propertyName)
        {
            LivestockMutilation lm = new();
            Assert.PropertyChanged(lm, propertyName, () => {
                lm.Biscuits = biscuits;
            });
        }

        /// <summary>
        /// Tests that changing Gravy notifys the property change
        /// </summary>
        /// <param name="gravy">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingGravyShouldNotifyOfPropertyChanges(bool gravy, string propertyName)
        {
            LivestockMutilation lm = new();
            Assert.PropertyChanged(lm, propertyName, () =>
            {
                lm.Gravy = gravy;
            });
        }
    }
}
