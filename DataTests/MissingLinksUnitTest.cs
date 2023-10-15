using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the MissingLinks class
    /// </summary>
    public class MissingLinksUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Missing Links has 2 links
        /// </summary>
        [Fact]
        public void DefaultCountShouldBe2Links()
        {
            MissingLinks ml = new();
            Assert.Equal(2u, ml.Count);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of sausage links</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void NameShouldAlwaysBeMissingLinks(uint count)
        {
            MissingLinks ml = new() { Count = count };
            Assert.Equal("Missing Links", ml.Name);
        }

        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the description does not change
        /// </summary>
        /// <param name="count">The number of sausage links</param>
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
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal("Sizzling pork sausage links.", ml.Description);
        }

        /// <summary>
        /// This test verifies that a MissingLinks's count cannot exceed 8, and 
        /// if it is attempted, the count will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveEight()
        {
            MissingLinks ml = new();
            ml.Count = 9;
            Assert.Equal(8u, ml.Count);
        }

        /// <summary>
        /// This tests that the count should be between 1 and 8
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
        [InlineData(8, 8)]
        [InlineData(9, 8)]
        public void CountShouldBeBetweenOneAndEight(uint count, uint expected)
        {
            MissingLinks ml = new MissingLinks();
            ml.Count = count;
            Assert.Equal(expected, ml.Count);
        }

        /// <summary>
        /// This test checks the price of the MissingLinks, per link added
        /// </summary>
        /// <param name="count">The number of links</param>
        /// <param name="price">The price of the Missing Links</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            MissingLinks ml = new();
            ml.Count = count;
            Assert.Equal(price, ml.Price);
        }

        /// <summary>
        /// This test checks the calories of the MissingLinks, per link added
        /// </summary>
        /// <param name="count">The number of links</param>
        /// <param name="calories">The expected calories, given the specfied count</param>
        [Theory]
        [InlineData(1, 391)]
        [InlineData(2, 391 + 391)]
        [InlineData(3, 391 + 391 + 391)]
        [InlineData(4, 391 + 391 + 391 + 391)]
        [InlineData(5, 391 + 391 + 391 + 391 + 391)]
        [InlineData(6, 391 + 391 + 391 + 391 + 391 + 391)]
        [InlineData(7, 391 + 391 + 391 + 391 + 391 + 391 + 391)]
        [InlineData(8, 391 + 391 + 391 + 391 + 391 + 391 + 391 + 391)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new();
            ml.Count = count;
            Assert.Equal(calories, ml.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Missing Links
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        /// <param name="instructions">The expected special instruction</param>
        [Theory]
        [InlineData(1, new string[] { "1 links" })]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 links" })]
        [InlineData(4, new string[] { "4 links" })]
        [InlineData(5, new string[] { "5 links" })]
        [InlineData(6, new string[] { "6 links" })]
        [InlineData(7, new string[] { "7 links" })]
        [InlineData(8, new string[] { "8 links" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the MissingLinks can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestMissingLinksSideItem()
        {
            MissingLinks missingLinks = new();
            Assert.IsAssignableFrom<Side>(missingLinks);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<IMenuItem>(ml);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            MissingLinks ml = new();
            string name = ml.ToString();
            Assert.Equal("Missing Links", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ml);
        }

        /// <summary>
        /// Tests that changing the count notifys the property change
        /// </summary>
        /// <param name="count">The size being passed in</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(1, "SpecialInstructions")]
        [InlineData(4, "SpecialInstructions")]
        [InlineData(8, "SpecialInstructions")]
        [InlineData(1, "Price")]
        [InlineData(2, "Price")]
        [InlineData(8, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(2, "Calories")]
        [InlineData(8, "Calories")]
        public void ChangingCountShouldNotifyOfPropertyChanges(uint count, string propertyName)
        {
            MissingLinks ml = new();
            Assert.PropertyChanged(ml, propertyName, () => {
                ml.Count = count;
            });
        }
    }
}
