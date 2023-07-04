using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Groups = new HashSet<Group>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<Group> Groups { get; set; }
    }
}
