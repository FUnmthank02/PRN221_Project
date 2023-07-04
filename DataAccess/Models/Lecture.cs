using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Groups = new HashSet<Group>();
        }

        public int LectureId { get; set; }
        public string LectureName { get; set; } = null!;
        public string Campus { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Group> Groups { get; set; }
    }
}
