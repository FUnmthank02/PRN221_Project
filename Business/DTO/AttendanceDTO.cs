using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public bool Status { get; set; }

        public virtual SessionDTO Session { get; set; } = null!;
        public virtual StudentDTO Student { get; set; } = null!;
    }
}
