using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            Sessions = new HashSet<Session>();
        }

        public int SlotId { get; set; }
        public string Start { get; set; } = null!;
        public string End { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
