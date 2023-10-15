using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website;
//using TheFlyingSaucer.Website;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for searching and filtering functionality
    /// </summary>
    public class SearchAndFilterUnitTest
    {
        /*
        /// <summary>
        /// Test if searching returns expected items
        /// </summary>
        /// <param name="searchTerms">The item searched</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Crashed Saucer")]
        [InlineData("Missing Links")]
        public void SearchReturnsMatchingItems(string searchTerms)
        {
            List<IMenuItem> expectedItems = new List<IMenuItem>
            {
                new CrashedSaucer(),
                new MissingLinks()
            };
            IEnumerable<IMenuItem> actualItems = MenuDatabase.Search(searchTerms);

            Assert.Equal(expectedItems, actualItems);
        }
        

        /// <summary>
        /// Test if filters return expected items
        /// </summary>
        /// <param name="priceMin">The min price</param>
        /// <param name="priceMax">The max price</param>
        /// <param name="calMin">The min calories</param>
        /// <param name="">The max calories</param>
        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("4.99", "6.99", "400", "800")]
        [InlineData("5.99", "7.99", null, null)]
        [InlineData(null, null, "500", "1000")]
        public void FIlterReturnsMathcingItems(string priceMin, string priceMax, string calMin, string calMax)
        {
            List<IMenuItem> expectedItems = new List<IMenuItem>
            {
                new MissingLinks()
            };

            IEnumerable<IMenuItem> actualItems = MenuDatabase.Filter(MenuDatabase.All, priceMin, priceMax, calMin, calMax);

            Assert.Equal(expectedItems, actualItems);
        }
        */
    }
}
