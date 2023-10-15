using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Menu class
    /// </summary>
    public class MenuUnitTest
    {
        /// <summary>
        /// Checks that the entrees count matches.
        /// </summary>
        [Fact]
        public void CheckEntreesCountMatch()
        {
            int expectedCount = 4;
            int actualCount = Menu.Entrees.Count();
            Assert.Equal(expectedCount, actualCount);
        }

        /// <summary>
        /// Checks that the sides count matches.
        /// </summary>
        [Fact]
        public void CheckSidesCountMatch()
        {
            int expectedCount = 6;
            int actualCount = Menu.Sides.Count();
            Assert.Equal(expectedCount, actualCount);
        }

        /// <summary>
        /// Checks that the drinks count matches.
        /// </summary>
        [Fact]
        public void CheckDrinksCountMatch()
        {
            int expectedCount = 18;
            int actualCount = Menu.Drinks.Count() * 3;
            Assert.Equal(expectedCount, actualCount);
        }
        /*
        /// <summary>
        /// Checks that the FullMenu contains all menu items.
        /// </summary>
        [Fact]
        public void FullMenuContainsAllMenuItems()
        {
            List<IMenuItem> expectedItems = new List<IMenuItem>();
            expectedItems.AddRange(Menu.Entrees);
            expectedItems.AddRange(Menu.Sides);
            expectedItems.AddRange(Menu.Drinks);
            List<IMenuItem> actualItems = new List<IMenuItem>(Menu.FullMenu);

            Assert.Equal(expectedItems, actualItems);
        }
        */
    }
}
