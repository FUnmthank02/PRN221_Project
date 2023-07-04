using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Enroll
    {
        public int EnrollId { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
