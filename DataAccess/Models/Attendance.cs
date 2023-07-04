using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public bool Status { get; set; }

        public virtual Session Session { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
