namespace PRN221_Project.Business.IRepository
{
    public interface IAuthenticationRepository
    {
        public int? LogIn(string username, string password);
        public int? ChangePassword(string newPass, int lectureId);
        public bool CheckUserExistByOldPassword(string oldPass, int lectureId);
    }
}
