using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class EnrollDTO
    {
        public int EnrollId { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public virtual GroupDTO Group { get; set; } = null!;
        public virtual StudentDTO Student { get; set; } = null!;
    }
}
