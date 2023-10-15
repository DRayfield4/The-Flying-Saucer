using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the FlyingSaucer class
    /// </summary>
    public class FlyingSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Flying Saucer has 6 panacakes
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            FlyingSaucer fs = new();
            Assert.Equal(6u, fs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Flying Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Syrup);
        }

        /// <summary>
        /// Checks that an unmodified Flying Saucer is served with whipped cream
        /// </summary>
        [Fact]
        public void DefaultServedWithWhippedCream()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.WhippedCream);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Berries);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void NameShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.Name);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the description does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void DescriptionShouldAlwaysBeTheSame(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.", fs.Description);
        }

        /// <summary>
        /// This test verifies that a FlyingSaucer's StackSize cannot exceed 12, and 
        /// if it is attempted, the StackSize will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            FlyingSaucer fs = new();
            fs.StackSize = 13;
            Assert.Equal(12u, fs.StackSize);
        }

        /// <summary>
        /// This test checks the price of the FlyingSaucer, per pancake added
        /// </summary>
        /// <param name="stackSize">The number of slices included</param>
        /// <param name="price">The price of the CrashedSaucer</param>
        [Theory]
        [InlineData(6, 8.50)]
        [InlineData(7, 8.50 + 0.75)]
        [InlineData(8, 8.50 + 0.75 + 0.75)]
        [InlineData(9, 8.50 + 0.75 + 0.75 + 0.75)]
        [InlineData(10, 8.50 + 0.75 + 0.75 + 0.75 + 0.75)]
        [InlineData(11, 8.50 + 0.75 + 0.75 + 0.75 + 0.75 + 0.75)]
        [InlineData(12, 8.50 + 0.75 + 0.75 + 0.75 + 0.75 + 0.75 + 0.75)]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            FlyingSaucer fs = new();
            fs.StackSize = stackSize;
            Assert.Equal(price, fs.Price);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(6, true, true, true, 64 * 6 + 32 + 414 + 89)]
        [InlineData(0, true, true, true, 64 * 0 + 32 + 414 + 89)]
        [InlineData(12, true, true, true, 64 * 12 + 32 + 414 + 89)]
        [InlineData(6, true, false, true, 64 * 6 + 32 + 0 + 89)]
        [InlineData(6, false, false, true, 64 * 6 + 0 + 0 + 89)]
        [InlineData(3, true, false, false, 64 * 3 + 32 + 0 + 0)]
        [InlineData(8, false, false, false, 64 * 8 + 0 + 0 + 0)]
        [InlineData(11, true, true, false, 64 * 11 + 32 + 414 + 0)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool whippedCream, bool berries, uint calories)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal(calories, fs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="whippedCream">If served with whipped cream</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, true, true, new string[] {})]
        [InlineData(4, true, true, true, new string[] { "4 Pancakes" })]
        [InlineData(6, false, true, true, new string[] { "Hold syrup" })]
        [InlineData(6, true, false, true, new string[] { "Hold whipped cream" })]
        [InlineData(6, true, true, false, new string[] { "Hold berries" })]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool whippedCream, bool berries, string[] instructions)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach(string instruction in instructions)
            {
                Assert.Contains(instruction, fs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<IMenuItem>(fs);
        }

        /// <summary>
        /// Test to see if the Flying Saucer can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestFlyingSaucerEntreeItem()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<Entree>(fs);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            FlyingSaucer fs = new();
            string name = fs.ToString();
            Assert.Equal("Flying Saucer", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(fs);
        }

        /// <summary>
        /// Tests that changing the size notifys the property change
        /// </summary>
        /// <param name="size">The size being passed in</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(4, "SpecialInstructions")]
        [InlineData(6, "SpecialInstructions")]
        [InlineData(12, "SpecialInstructions")]
        [InlineData(2, "Price")]
        [InlineData(4, "Price")]
        [InlineData(12, "Price")]
        [InlineData(2, "Calories")]
        [InlineData(4, "Calories")]
        [InlineData(12, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint size, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () => {
                fs.StackSize = size;
            });
        }

        /// <summary>
        /// Tests that changing Syrup notifys the property change
        /// </summary>
        /// <param name="syrup">If it has syrup</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingSyrupShouldNotifyOfPropertyChanges(bool syrup, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.Syrup = syrup;
            });
        }

        /// <summary>
        /// Tests that changing Whipped Cream notifys the property change
        /// </summary>
        /// <param name="whipCream">If it has whipped cream</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingWhippedCreamShouldNotifyOfPropertyChanges(bool whipCream, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.WhippedCream = whipCream;
            });
        }

        /// <summary>
        /// Tests that changing Berries notifys the property change
        /// </summary>
        /// <param name="berries">If it has whipped cream</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingBerriesShouldNotifyOfPropertyChanges(bool berries, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.Berries = berries;
            });
        }
    }
}