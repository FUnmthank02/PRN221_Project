using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Business.Helper;
using PRN221_Project.Business.IRepository;

namespace PRN221_Project.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        IAuthenticationRepository _authenticationRepository;


        public LoginModel(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_NULL_FIELD;
                return Redirect(Constants.ROUTE_SIGN_IN);
            }
            else
            {
                int? lectureId = _authenticationRepository.LogIn(username, password);
                if (lectureId == null)
                {
                    TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_WRONG_ACCOUNT;
                    return Redirect(Constants.ROUTE_SIGN_IN);
                } else
                {
                    // save lectureId to session
                    Helper.SetIdToSession(HttpContext.Session, Constants.LECTURE_ID_KEY, (int)lectureId);
                    return Redirect(Constants.ROUTE_HOME);
                }
            }
        }
    }
}
