using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the GlowingHaystack class
    /// </summary>
    public class GlowingHaystackUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Glowing Haystack is served with green chile sauce
        /// </summary>
        [Fact]
        public void DefaultServedWithGreenChileSauce()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.GreenChileSauce);
        }

        /// <summary>
        /// Checks that an unaltered Glowing Haystack is served with sour cream
        /// </summary>
        [Fact]
        public void DefaultServedWithSourCream()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.SourCream);
        }

        /// <summary>
        /// Checks that an unaltered Glowing Haystack is served with tomatoes
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.Tomatoes);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the name does not change
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack is served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public void NameShouldAlwaysBeGlowingHaystack(bool greenChileSauce, bool sourCream, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };
            Assert.Equal("Glowing Haystack", gh.Name);
        }

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the description does not change
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack is served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public void DescriptionShouldAlwaysBeTheSame(bool greenChileSauce, bool sourCream, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };
            Assert.Equal("Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.", gh.Description);
        }

        /// <summary>
        /// This test checks the price of the GlowingHaystack
        /// </summary>
        /// <param name="price">The price of the GlowingHaystack</param>
        [Theory]
        [InlineData(2.00)]
        public void PriceShouldBeCorrect(decimal price)
        {
            GlowingHaystack gh = new();
            Assert.Equal(price, gh.Price);
        }

        /// <summary>
        /// This test checks the calories of the GlowingHaystack
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack is served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, 470 + 15 + 23 + 22)]
        [InlineData(false, true, true, 470 + 0 + 23 + 22)]
        [InlineData(true, false, true, 470 + 15 + 0 + 22)]
        [InlineData(true, true, false, 470 + 15 + 23 + 0)]
        [InlineData(false, true, false, 470 + 0 + 23 + 0)]
        [InlineData(false, false, true, 470 + 0 + 0 + 22)]
        [InlineData(false, false, false, 470 + 0 + 0 + 0)]
        public void CaloriesShouldBeCorrect(bool greenChileSauce, bool sourCream, bool tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };
            Assert.Equal(calories, gh.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Glowing Haystack
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack is served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, new string[] { })]
        [InlineData(false, true, true, new string[] { "Hold Green Chile Sauce" })]
        [InlineData(true, false, true, new string[] { "Hold Sour Cream" })]
        [InlineData(true, true, false, new string[] { "Hold Tomatoes" })]
        public void SpecialInstructionsRelfectsState(bool greenChileSauce, bool sourCream, bool tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<IMenuItem>(gh);
        }

        /// <summary>
        /// Test to see if the Glowing Haystack can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestGlowingHaystackEntreeItem()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<Side>(gh);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            GlowingHaystack gh = new();
            string name = gh.ToString();
            Assert.Equal("Glowing Haystack", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(gh);
        }

        /// <summary>
        /// Tests that changing GreenChileSauce notifys the property change
        /// </summary>
        /// <param name="gcs">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingGreenChileSauceShouldNotifyOfPropertyChanges(bool gcs, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.GreenChileSauce = gcs;
            });
        }

        /// <summary>
        /// Tests that changing SourCream notifys the property change
        /// </summary>
        /// <param name="sc">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingSourCreamShouldNotifyOfPropertyChanges(bool sc, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.SourCream = sc;
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
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Tomatoes = tom;
            });
        }
    }
}
