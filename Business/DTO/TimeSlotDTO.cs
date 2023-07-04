using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class TimeSlotDTO
    {
        public TimeSlotDTO()
        {
            Sessions = new HashSet<SessionDTO>();
        }

        public int SlotId { get; set; }
        public string Start { get; set; } = null!;
        public string End { get; set; } = null!;

        public virtual ICollection<SessionDTO> Sessions { get; set; }
    }
}
