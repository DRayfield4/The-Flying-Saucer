using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CropCircle class
    /// </summary>
    public class CropCircleUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Crop Circle is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            CropCircle cc = new CropCircle();
            Assert.True(cc.Berries);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the name does not change
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCropCircle(bool berries)
        {
            CropCircle cc = new() { Berries = berries };
            Assert.Equal("Crop Circle", cc.Name);
        }

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the description does not change
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DescriptionAlwaysBeTheSame(bool berries)
        {
            CropCircle cc = new() { Berries = berries };
            Assert.Equal("Oatmeal topped with mixed berries.", cc.Description);
        }

        /// <summary>
        /// This test checks the price of the CropCircle
        /// </summary>
        /// <param name="price">The price of the CropCircle</param>
        [Theory]
        [InlineData(2.00)]
        public void PriceShouldBeCorrect(decimal price)
        {
            CropCircle cc = new();
            Assert.Equal(price, cc.Price);
        }

        /// <summary>
        /// This test checks the calories of the CropCircle
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, 158 + 89)]
        [InlineData(false, 158 + 0)]
        public void CaloriesShouldBeCorrect(bool berries, uint calories)
        {
            CropCircle cc = new()
            {
                Berries = berries,
            };
            Assert.Equal(calories, cc.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crop Circle
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "Hold Berries" })]
        public void SpecialInstructionsRelfectsState(bool berries, string[] instructions)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cc.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cc.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            CropCircle cropCircle = new CropCircle();
            Assert.IsAssignableFrom<IMenuItem>(cropCircle);
        }

        /// <summary>
        /// Test to see if the Crop Circle can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestCropCircleSideItem()
        {
            CropCircle cropCircle = new();
            Assert.IsAssignableFrom<Side>(cropCircle);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CropCircle cc = new();
            string name = cc.ToString();
            Assert.Equal("Crop Circle", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cc);
        }

        /// <summary>
        /// Tests that changing Berries notifys the property change
        /// </summary>
        /// <param name="berries">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingBerriesShouldNotifyOfPropertyChanges(bool berries, string propertyName)
        {
            CropCircle cc = new();
            Assert.PropertyChanged(cc, propertyName, () =>
            {
                cc.Berries = berries;
            });
        }
    }
}
