using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Business.Helper;

namespace PRN221_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostLogout()
        {
            Helper.RemoveIdFromSession(HttpContext.Session, Constants.LECTURE_ID_KEY);
            return Redirect(Constants.ROUTE_HOME);
        }
    }
}