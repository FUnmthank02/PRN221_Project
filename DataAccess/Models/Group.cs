using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Group
    {
        public Group()
        {
            Enrolls = new HashSet<Enroll>();
            Sessions = new HashSet<Session>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public int LectureId { get; set; }
        public int SubjectId { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Enroll> Enrolls { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
