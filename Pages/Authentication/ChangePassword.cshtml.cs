using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Business.Helper;
using PRN221_Project.Business.IRepository;

namespace PRN221_Project.Pages.Authentication
{
    public class ChangePasswordModel : PageModel
    {
        IAuthenticationRepository _authenticationRepository;


        public ChangePasswordModel(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string oldPass, string newPass, string cfPass)
        {
            if (!string.IsNullOrEmpty(oldPass) && !string.IsNullOrEmpty(newPass) && !string.IsNullOrEmpty(cfPass))
            {
                // get lectureId from session
                int? lectureId = Helper.GetIdFromSession(HttpContext.Session, Constants.LECTURE_ID_KEY);
                if (lectureId.HasValue)
                {
                    // handle check old pass
                    if (_authenticationRepository.CheckUserExistByOldPassword(oldPass, (int)lectureId))
                    {
                        // handle change password
                        if (_authenticationRepository.ChangePassword(newPass, (int)lectureId) > 0)
                        {
                            TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_CHANGE_PASSWORD_SUCCESSFULLY;
                        }
                        else
                        {
                            TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_CHANGE_PASSWORD_FAIL;
                        }
                    }
                    else
                    {
                        TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_INCORRECT_OLD_PASSSWORD;
                    }
                }
            }
            return Redirect(Constants.ROUTE_CHANGE_PASSWORD);
        }

        public JsonResult OnPostAfterChangePasswordSuccess()
        {
            Helper.RemoveIdFromSession(HttpContext.Session, Constants.LECTURE_ID_KEY);
            return new JsonResult(Constants.ROUTE_SIGN_IN);
        }
    }
}
