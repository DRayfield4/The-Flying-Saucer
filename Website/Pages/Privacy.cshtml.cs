using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    /// <summary>
    /// The model for the Privacy razor page.
    /// </summary>
    public class PrivacyModel : PageModel
    {
        /// <summary>
        /// Used to log messages from the Privacy razor page.
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor initializes the PrivacyModel logger with an ILogger object.
        /// </summary>
        /// <param name="logger">The logger</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
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