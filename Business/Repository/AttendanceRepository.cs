using AutoMapper;
using PRN221_Project.Business.DTO;
using PRN221_Project.Business.IRepository;
using PRN221_Project.DataAccess.Manager;
using PRN221_Project.DataAccess.Models;

namespace PRN221_Project.Business.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        PRN221_AssContext _context;
        IMapper _mapper;
        private AttendanceManager manager;
        public AttendanceRepository(PRN221_AssContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SessionDTO> GetSessions(DateTime startDate, DateTime endDate)
        {
            List<Session> listSessions;
            manager = new AttendanceManager(_context);
            listSessions = manager.GetSessions(startDate, endDate);

            List<SessionDTO> listSessionsDTO = _mapper.Map<List<SessionDTO>>(listSessions);
            return listSessionsDTO;
        }

        public List<EnrollDTO> GetEnrollsByGroupId(int groupId)
        {
            List<Enroll> listEnrolls;
            manager = new AttendanceManager(_context);
            listEnrolls = manager.GetEnrollsByGroupId(groupId);

            List<EnrollDTO> listEnrollsDTO = _mapper.Map<List<EnrollDTO>>(listEnrolls);
            return listEnrollsDTO;
        }

        public List<AttendanceDTO> GetAttendancesBySessionId(int sessionId)
        {
            manager = new AttendanceManager(_context);
            var attendance = manager.GetAttendancesBySessionId(sessionId);

            List<AttendanceDTO> attendanceDTO = _mapper.Map<List<AttendanceDTO>>(attendance);
            return attendanceDTO;
        }

        public int AddAttendance(AttendanceDTO attendanceDto)
        {
            manager = new AttendanceManager(_context);
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            return manager.AddAttendance(attendance);
        }
        
        public int UpdateAttendance(AttendanceDTO attendanceDto)
        {
            manager = new AttendanceManager(_context);
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            return manager.UpdateAttendance(attendance);
        }
    }
}
