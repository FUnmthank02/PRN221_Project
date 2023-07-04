using PRN221_Project.DataAccess.Models;

namespace PRN221_Project.DataAccess.Manager
{
    public class AuthenticationManager
    {
        PRN221_AssContext _context;
        public AuthenticationManager(PRN221_AssContext context)
        { _context = context; }

        public int? LogIn(string username, string password)
        {
            var user = _context.Lectures.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return null;
            }

            return user.LectureId;
        }
    }
}
