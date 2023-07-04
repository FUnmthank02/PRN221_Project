using System;
using System.Collections.Generic;

namespace PRN221_Project.DataAccess.Models
{
    public partial class Session
    {
        public Session()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int SessionId { get; set; }
        public int GroupId { get; set; }
        public int RoomId { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual TimeSlot Slot { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
