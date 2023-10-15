using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CrashedSaucer class
    /// </summary>
    public class CrashedSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Crashed Saucer has 2 slices
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBe2Slices()
        {
            CrashedSaucer cs = new();
            Assert.Equal(2u, cs.StackSize);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with syrup
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with butter
        /// </summary>
        [Fact]
        public void DefaultServedWithButter()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Butter);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of slices included</param>
        /// <param name="syrup">If the Crashed Saucer has syrup</param>
        /// <param name="butter">If the Crashed Saucer has butter</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(2, true, true)]
        [InlineData(0, true, true)]
        [InlineData(6, true, true)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, false)]
        [InlineData(5, false, false)]
        [InlineData(5, true, true)]
        public void NameShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the description does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        [Theory]
        [InlineData(2, true, true)]
        [InlineData(0, true, true)]
        [InlineData(6, true, true)]
        [InlineData(3, true, false)]
        [InlineData(3, false, false)]
        [InlineData(4, true, false)]
        [InlineData(5, false, false)]
        [InlineData(5, true, true)]
        public void DescriptionShouldAlwaysBeTheSame(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("A stack of crispy french toast smothered in syrup and topped with a pat of butter.", cs.Description);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveSix()
        {
            CrashedSaucer cs = new();
            cs.StackSize = 7;
            Assert.Equal(6u, cs.StackSize);
        }

        /// <summary>
        /// This test checks the price of the CrashedSaucer, per slice added
        /// </summary>
        /// <param name="stackSize">The number of slices included</param>
        /// <param name="price">The price of the CrashedSaucer</param>
        [Theory]
        [InlineData(2, 6.45)]
        [InlineData(3, 6.45 + 1.50)]
        [InlineData(4, 6.45 + 1.50 + 1.50)]
        [InlineData(5, 6.45 + 1.50 + 1.50 + 1.50)]
        [InlineData(6, 6.45 + 1.50 + 1.50 + 1.50 + 1.50)]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            CrashedSaucer cs = new();
            cs.StackSize = stackSize;
            Assert.Equal(price, cs.Price);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of slices included</param>
        /// <param name="syrup">If the Crashed Saucer has syrup</param>
        /// <param name="butter">If the Crashed Saucer has butter</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs
        /// </remarks>
        [Theory]
        [InlineData(2, true, true, 149 * 2 + 52 + 35)]
        [InlineData(0, true, true, 149 * 0 + 52 + 35)]
        [InlineData(6, true, true, 149 * 6 + 52 + 35)]
        [InlineData(2, true, false, 149 * 2 + 52 + 0)]
        [InlineData(4, false, true, 149 * 4 + 0 + 35)]
        [InlineData(5, false, false, 149 * 5 + 0 + 0)]
        [InlineData(5, true, true, 149 * 5 + 52 + 35)]
        [InlineData(3, false, true, 149 * 3 + 0 + 35)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal(calories, cs.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="stackSize">The number of slices</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="butter">If served wit hbutter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, true, true, new string[] {})]
        [InlineData(4, true, true, new string[] { "4 Slices" })]
        [InlineData(2, false, true, new string[] { "Hold syrup" })]
        [InlineData(2, true, false, new string[] { "Hold butter" })]
        public void SpecialInstructionsReflectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());

        }

        #endregion

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<IMenuItem>(cs);
        }

        /// <summary>
        /// Test to see if the Crop Circle can be cast as an Entree.
        /// </summary>
        [Fact]
        public void TestCrashedSaucerEntreeItem()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<Entree>(cs);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CrashedSaucer cs = new();
            string name = cs.ToString();
            Assert.Equal("Crashed Saucer", name);
        }

        /// <summary>
        /// Tests if it implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cs);
        }

        /// <summary>
        /// Tests that changing the size notifys the property change
        /// </summary>
        /// <param name="size">The size being passed in</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(3, "SpecialInstructions")]
        [InlineData(4, "SpecialInstructions")]
        [InlineData(6, "SpecialInstructions")]
        [InlineData(2, "Price")]
        [InlineData(4, "Price")]
        [InlineData(6, "Price")]
        [InlineData(2, "Calories")]
        [InlineData(4, "Calories")]
        [InlineData(6, "Calories")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint size, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () => {
                cs.StackSize = size;
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
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () =>
            {
                cs.Syrup = syrup;
            });
        }

        /// <summary>
        /// Tests that changing butter notifys the property change
        /// </summary>
        /// <param name="butter">If it has whipped cream</param>
        /// <param name="propertyName">The name of the property being checked</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingWhippedCreamShouldNotifyOfPropertyChanges(bool butter, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () =>
            {
                cs.Butter = butter;
            });
        }
    }
}
