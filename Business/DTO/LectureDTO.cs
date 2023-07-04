using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class LectureDTO
    {
        public LectureDTO()
        {
            Groups = new HashSet<GroupDTO>();
        }

        public int LectureId { get; set; }
        public string LectureName { get; set; } = null!;
        public string Campus { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<GroupDTO> Groups { get; set; }
    }
}
