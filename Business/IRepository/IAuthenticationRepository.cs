namespace PRN221_Project.Business.IRepository
{
    public interface IAuthenticationRepository
    {
        public int? LogIn(string username, string password);
    }
}
