using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class GroupDTO
    {
        public GroupDTO()
        {
            Enrolls = new HashSet<EnrollDTO>();
            Sessions = new HashSet<SessionDTO>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public int LectureId { get; set; }
        public int SubjectId { get; set; }

        public virtual LectureDTO Lecture { get; set; } = null!;
        public virtual SubjectDTO Subject { get; set; } = null!;
        public virtual ICollection<EnrollDTO> Enrolls { get; set; }
        public virtual ICollection<SessionDTO> Sessions { get; set; }
    }
}
