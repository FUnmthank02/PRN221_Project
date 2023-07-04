using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class RoomDTO
    {
        public RoomDTO()
        {
            Sessions = new HashSet<SessionDTO>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public virtual ICollection<SessionDTO> Sessions { get; set; }
    }
}
