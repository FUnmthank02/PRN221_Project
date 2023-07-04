using AutoMapper;
using PRN221_Project.Business.IRepository;
using PRN221_Project.DataAccess.Manager;
using PRN221_Project.DataAccess.Models;

namespace PRN221_Project.Business.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        PRN221_AssContext _context;
        IMapper _mapper;
        private AuthenticationManager manager;
        public AuthenticationRepository(PRN221_AssContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int? LogIn(string username, string password)
        {
            int? lectureId;
            manager = new AuthenticationManager(_context);
            lectureId = manager.LogIn(username, password);

            return lectureId;
        }
    }
}
