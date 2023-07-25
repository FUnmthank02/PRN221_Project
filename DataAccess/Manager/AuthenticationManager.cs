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
        public bool CheckUserExistByOldPassword(string oldPass, int lectureId)
        {
            var user = _context.Lectures.FirstOrDefault(x => x.LectureId == lectureId && x.Password.Equals(oldPass));
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public int? ChangePassword(string newPass, int lectureId)
        {
            var user = _context.Lectures.FirstOrDefault(x => x.LectureId == lectureId);
            if (user == null)
            {
                return null;
            }
            else
            {
                user.Password = newPass;
                return _context.SaveChanges();
            }
        }
    }
}
