using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    /// <summary>
    /// The model for the About razor page.
    /// </summary>
    public class AboutModel : PageModel
    {
        /// <summary>
        /// Used to log messages from the About razor page.
        /// </summary>
        private readonly ILogger<AboutModel> _logger;

        /// <summary>
        /// Constructor initializes the AboutModel logger with an ILogger object.
        /// </summary>
        /// <param name="logger">The logger</param>
        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called when the page is loaded.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
