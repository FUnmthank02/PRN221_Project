using PRN221_Project.Business.DTO;
using PRN221_Project.DataAccess.Models;

namespace PRN221_Project.Business.IRepository
{
    public interface IAttendanceRepository
    {
        public List<SessionDTO> GetSessions(DateTime startDate, DateTime endDate);
        public List<EnrollDTO> GetEnrollsByGroupId(int groupId);
        public List<AttendanceDTO> GetAttendancesBySessionId(int sessionId);
        public int AddAttendance(AttendanceDTO attendance);
        public int UpdateAttendance(AttendanceDTO attendance);
    }
}
