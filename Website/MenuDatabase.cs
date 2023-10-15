using TheFlyingSaucer.Data;

namespace Website
{
    /// <summary>
    /// A class representing menu items
    /// </summary>
    public class MenuDatabase
    {
        /// <summary>
        /// A list of menu items
        /// </summary>
        private static List<IMenuItem> items = new();

        /// <summary>
        /// Gets all the items in the menu database
        /// </summary>
        public static IEnumerable<IMenuItem> All { get { return items; } }

        /// <summary>
        /// Searches the menu in the database for matches
        /// </summary>
        /// <param name="terms">The terms to search for</param>
        /// <returns>The results of the search</returns>
        public static IEnumerable<IMenuItem> Search(string terms)
        {
            List<IMenuItem> results = new();
            // null check
            if (terms == null)
            {
                return All;
            }

            foreach (IMenuItem item in All)
            {
                // Add the menu item if the name is a match
                if (item.Name != null && item.Name.Contains(terms, StringComparison.CurrentCultureIgnoreCase))
                {
                    results.Add(item);
                }
            }

            return results;
        }
    }
}
