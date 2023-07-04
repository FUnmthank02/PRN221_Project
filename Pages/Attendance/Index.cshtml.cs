using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Business.DTO;
using PRN221_Project.Business.IRepository;
using System.Globalization;

namespace PRN221_Project.Pages.Attendance
{
    public class IndexModel : PageModel
    {
        IAttendanceRepository _attendanceRepository;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<SessionDTO> listSessions { get; set; }
        public List<SessionDTO> listSlot1 { get; set; }
        public List<SessionDTO> listSlot2 { get; set; }
        public List<SessionDTO> listSlot3 { get; set; }
        public List<SessionDTO> listSlot4 { get; set; }
        public string SelectedWeek { get; set; }


        public IndexModel(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public void OnGet(string selectedWeek)
        {
            if (string.IsNullOrEmpty(selectedWeek))
            {
                GetCurrentWeek();
            }
            else
            {
                // split selectedWeek to startDate and endDate
                string[] rangeDate = selectedWeek.Split(" ");
                string startDateString = rangeDate[0];
                string endDateString = rangeDate[1];

                // Parse from string to DateTime
                startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                endDate = DateTime.ParseExact(endDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            SelectedWeek = $"{startDate.ToString("yyyy-MM-dd")} {endDate.ToString("yyyy-MM-dd")}";
            listSessions = _attendanceRepository.GetSessions(startDate, endDate);
            GetSubListBySlot();
        }

        private void GetCurrentWeek()
        {
            DateTime today = DateTime.Today;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime monday = today.AddDays(daysUntilMonday - 7); // Subtract 7 to get the Monday of the current week
            string startDateString = monday.ToString("yyyy-MM-dd");
            string endDateString = monday.AddDays(6).ToString("yyyy-MM-dd");

            startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            endDate = DateTime.ParseExact(endDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            SelectedWeek = $"{startDate.ToString("yyyy-MM-dd")} {endDate.ToString("yyyy-MM-dd")}";
        }

        private void GetSubListBySlot()
        {
            listSlot1 = listSessions.Where(s => s.SlotId == 1).ToList();
            listSlot2 = listSessions.Where(s => s.SlotId == 2).ToList();
            listSlot3 = listSessions.Where(s => s.SlotId == 3).ToList();
            listSlot4 = listSessions.Where(s => s.SlotId == 4).ToList();
        }
    }
}
