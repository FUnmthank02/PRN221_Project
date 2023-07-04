using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class StudentDTO
    {
        public StudentDTO()
        {
            Attendances = new HashSet<AttendanceDTO>();
            Enrolls = new HashSet<EnrollDTO>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;

        public virtual ICollection<AttendanceDTO> Attendances { get; set; }
        public virtual ICollection<EnrollDTO> Enrolls { get; set; }
    }
}
