using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            Enrolls = new HashSet<Enroll>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Enroll> Enrolls { get; set; }
    }
}
