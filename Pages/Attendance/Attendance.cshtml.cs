using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Business.DTO;
using PRN221_Project.Business.Helper;
using PRN221_Project.Business.IRepository;

namespace PRN221_Project.Pages
{
    public class AttendanceModel : PageModel
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public static int SessionId { get; set; }
        private static int GroupId { get; set; }
        public List<EnrollDTO> ListEnrolls { get; set; }
        public List<AttendanceDTO> ListAttendances { get; set; }

        [BindProperty]
        public List<bool> AttendanceValues { get; set; }

        public AttendanceModel(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
            AttendanceValues = new List<bool>();
        }

        public void OnGet(int sessionId, int groupId)
        {
            if (sessionId == null || groupId == null)
            {
                Redirect(Constants.ROUTE_TIME_TABLE);
            } else
            {
                SessionId = sessionId;
                GroupId = groupId;
                GetEnrollsByGroupId();
                GetAttendancesBySessionId();
            }
        }

        private void GetEnrollsByGroupId()
        {
            ListEnrolls = _attendanceRepository.GetEnrollsByGroupId(GroupId);
        }
        
        private void GetAttendancesBySessionId()
        {
            ListAttendances = _attendanceRepository.GetAttendancesBySessionId(SessionId);
        }
    }
}
