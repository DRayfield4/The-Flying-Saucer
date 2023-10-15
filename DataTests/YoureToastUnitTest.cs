namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the YoureToast class
    /// </summary>
    public class YoureToastUnitTest
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Youre Toast has 2 slices
        /// </summary>
        [Fact]
        public void DefaultCountShouldBe2Slices()
        {
            YoureToast to = new();
            Assert.Equal(2u, to.Count);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the YoureToast's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of toast slices</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void NameShouldAlwaysBeYouAreToast(uint count)
        {
            YoureToast to = new()
            {
                Count = count
            };
            Assert.Equal("You're Toast", to.Name);
        }

        /// <summary>
        /// This test checks that even as the YoureToast's state mutates, the description does not change
        /// </summary>
        /// <param name="count">The number of toast slices</param>
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
            YoureToast to = new()
            {
                Count = count
            };
            Assert.Equal("Texas toast.", to.Description);
        }

        /// <summary>
        /// This test verifies that a YoureToast's count cannot exceed 12, and 
        /// if it is attempted, the count will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveSix()
        {
            YoureToast to = new();
            to.Count = 13;
            Assert.Equal(12u, to.Count);
        }

        /// <summary>
        /// This tests that the count should be between 1 and 12
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
        [InlineData(13, 12)]
        [InlineData(20, 12)]
        public void CountShouldBeBetweenOneAndTwelve(uint count, uint expected)
        {
            YoureToast yt = new();
            yt.Count = count;
            Assert.Equal(expected, yt.Count);
        }

        /// <summary>
        /// This test checks the price of the YoureToast, per slice added
        /// </summary>
        /// <param name="count">The number of slices</param>
        /// <param name="price">The price of the YoureToast</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(6, 6)]
        [InlineData(7, 7)]
        [InlineData(10, 10)]
        [InlineData(12, 12)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            YoureToast to = new();
            to.Count = count;
            Assert.Equal(price, to.Price);
        }

        /// <summary>
        /// This test checks the calories of the YoureToast, per slice added
        /// </summary>
        /// <param name="count">The number of slices</param>
        /// <param name="calories">The calories of the YoureToast</param>
        [Theory]
        [InlineData(1, 100)]
        [InlineData(2, 100 + 100)]
        [InlineData(3, 100 + 100 + 100)]
        [InlineData(6, 100 + 100 + 100 + 100 + 100 + 100)]
        [InlineData(7, 100 + 100 + 100 + 100 + 100 + 100 + 100)]
        [InlineData(10, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100)]
        [InlineData(11, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100)]
        [InlineData(12, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YoureToast to = new();
            to.Count = count;
            Assert.Equal(calories, to.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the YoureToast
        /// </summary>
        /// <param name="count">The number of toast slices included</param>
        /// <param name="instructions">The expected special instruction</param>
        [Theory]
        [InlineData(1, new string[] { "1 slices" })]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 slices" })]
        [InlineData(5, new string[] { "5 slices" })]
        [InlineData(6, new string[] { "6 slices" })]
        [InlineData(10, new string[] { "10 slices" })]
        [InlineData(11, new string[] { "11 slices" })]
        [InlineData(12, new string[] { "12 slices" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YoureToast to = new() { Count = count };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, to.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, to.SpecialInstructions.Count());
        }

        #endregion

        /// <summary>
        /// Test to see if the YoureToast can be cast as a Side.
        /// </summary>
        [Fact]
        public void TestYoureToastSideItem()
        {
            YoureToast yt = new();
            Assert.IsAssignableFrom<Side>(yt);
        }

        /// <summary>
        /// Test to see if menu items can be cast as an IMenuItem.
        /// </summary>
        [Fact]
        public void TestMenuItem()
        {
            YoureToast yt = new();
            Assert.IsAssignableFrom<IMenuItem>(yt);
        }

        /// <summary>
        /// Tests the ToString override method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            YoureToast yt = new();
            string name = yt.ToString();
            Assert.Equal("You're Toast", name);
        }
    }
}
