using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class SubjectDTO
    {
        public SubjectDTO()
        {
            Groups = new HashSet<GroupDTO>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<GroupDTO> Groups { get; set; }
    }
}
