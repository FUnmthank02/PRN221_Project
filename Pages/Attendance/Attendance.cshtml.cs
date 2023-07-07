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

        public IActionResult OnPost()
        {
            GetEnrollsByGroupId();
            GetAttendancesBySessionId();

            // add new attendance if the list "attendances" is empty
            if (!ListAttendances.Any())
            {
                for (int i = 0; i < ListEnrolls.Count; i++)
                {
                    AttendanceDTO attendanceDto = GetNewAttendanceDTO(null, SessionId, ListEnrolls[i].StudentId, AttendanceValues[i]);

                    if (_attendanceRepository.AddAttendance(attendanceDto) > 0)
                    {
                        TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_ADD_ATTENDANCE_SUCCESSFULLY;
                    }
                }
            }
            else
            {   // update attendance
                for (int i = 0; i < ListEnrolls.Count; i++)
                {
                    foreach (AttendanceDTO item in ListAttendances)
                    {
                        if (ListEnrolls[i].StudentId == item.StudentId)
                        {
                            AttendanceDTO attendanceDto = GetNewAttendanceDTO(item.AttendanceId, SessionId, ListEnrolls[i].StudentId, AttendanceValues[i]);

                            if (_attendanceRepository.UpdateAttendance(attendanceDto) > 0)
                            {
                                TempData[Constants.MESSAGE_KEY_RESPONSE] = Constants.MESSAGE_UPDATE_ATTENDANCE_SUCCESSFULLY;
                            }
                        }
                    }
                }
            }

            return Redirect(Constants.ROUTE_TIME_TABLE);
        }

        // return new object attendanceDTO
        private AttendanceDTO GetNewAttendanceDTO(int? attendanceId, int sessionId, int studentId, bool status)
        {
            if (attendanceId.HasValue)
            {
                return new AttendanceDTO()
                {
                    AttendanceId = attendanceId.Value,
                    SessionId = sessionId,
                    StudentId = studentId,
                    Status = status,
                };
            }
            else
            {
                return new AttendanceDTO()
                {
                    SessionId = sessionId,
                    StudentId = studentId,
                    Status = status,
                };
            }
        }
    }
}
