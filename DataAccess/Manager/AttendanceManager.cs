using Microsoft.EntityFrameworkCore;
using PRN221_Project.DataAccess.Models;

namespace PRN221_Project.DataAccess.Manager
{
    public class AttendanceManager
    {
        PRN221_AssContext _context;
        public AttendanceManager(PRN221_AssContext context)
        { _context = context; }

        public List<Session> GetSessions(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Session> listSessions = _context.Sessions
                    .Include(o => o.Slot)
                    .Include(o => o.Room)
                    .Include(o => o.Group)
                        .ThenInclude(g => g.Subject) //include sub navigation property of Group
                    .Include(o => o.Group)
                        .ThenInclude(s => s.Lecture) //include sub navigation property of Group
                    .Where(o => o.Date >= startDate && o.Date <= endDate).ToList();

                return listSessions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Enroll> GetEnrollsByGroupId(int groupId)
        {
            try
            {
                List<Enroll> listEnrolls = _context.Enrolls
                    .Include(o => o.Student)
                    .Include(o => o.Group)
                        .ThenInclude(g => g.Subject) //include sub navigation property of Group
                    .Include(o => o.Group)
                        .ThenInclude(s => s.Lecture) //include sub navigation property of Group
                    .Where(o => o.GroupId == groupId).ToList();

                return listEnrolls;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Attendance> GetAttendancesBySessionId(int sessionId)
        {
            try
            {
                var  attendance = _context.Attendances
                     .Include(a => a.Student)
                     .Include(a => a.Session)
                         .ThenInclude(s => s.Group)
                     .Include(a => a.Session)
                         .ThenInclude(s => s.Room)
                     .Include(a => a.Session)
                         .ThenInclude(s => s.Slot)
                     .Where(a => a.SessionId == sessionId)
                     .ToList();

                return attendance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AddAttendance(Attendance attendance)
        {
            try
            {
                _context.Attendances.Add(attendance);
                return _context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public int UpdateAttendance(Attendance attendance)
        {
            try
            {
                var curAttendance = _context.Attendances.Find(attendance.AttendanceId);
                if (curAttendance == null)
                {
                    throw new Exception("Attendance not found");
                }
                _context.Entry(curAttendance).CurrentValues.SetValues(attendance);
                return _context.SaveChanges();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
