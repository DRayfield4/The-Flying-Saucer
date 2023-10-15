using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data;

namespace Website.Pages
{
    /// <summary>
    /// The model for the Index razor page.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The menu items
        /// </summary>
        public IEnumerable<IMenuItem> Items { get; set; }

        /// <summary>
        /// Used to log messages from the Index razor page.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// The terms to search for
        /// </summary>
        public string SearchTerms { get; set; }

        /// <summary>
        /// Whether to include entrees in the search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public bool Entrees { get; set; }

        /// <summary>
        /// Whether to include sides in the search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public bool Sides { get; set; }

        /// <summary>
        /// Whether to include drinks in the search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public bool Drinks { get; set; }

        /// <summary>
        /// The minimum price to search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string PriceMin { get; set; }

        /// <summary>
        /// The maximum price to search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string PriceMax { get; set; }

        /// <summary>
        /// The minimum calories to search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string CaloriesMin { get; set; }

        /// <summary>
        /// The maximum calories to search
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string CaloriesMax { get; set; }

        /// <summary>
        /// Constructor initializes the IndexModel logger with an ILogger object.
        /// </summary>
        /// <param name="logger">The logger</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called when the page is loaded.
        /// </summary>
        public void OnGet()
        {
            SearchTerms = Request.Query["SearchTerms"];
            Items = MenuDatabase.Search(SearchTerms);

            if (!string.IsNullOrEmpty(PriceMin))
            {
                Items = Items.Where(i => i.Price >= decimal.Parse(PriceMin));
            }

            if (!string.IsNullOrEmpty(PriceMax))
            {
                Items = Items.Where(i => i.Price <= decimal.Parse(PriceMax));
            }

            if (!string.IsNullOrEmpty(CaloriesMin))
            {
                Items = Items.Where(i => i.Calories >= int.Parse(CaloriesMin));
            }

            if (!string.IsNullOrEmpty(CaloriesMax))
            {
                Items = Items.Where(i => i.Calories <= int.Parse(CaloriesMax));
            }
        }
    }
}