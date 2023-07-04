using System;
using System.Collections.Generic;

namespace PRN221_Project.Business.DTO
{
    public partial class SessionDTO
    {
        public SessionDTO()
        {
            Attendances = new HashSet<AttendanceDTO>();
        }

        public int SessionId { get; set; }
        public int GroupId { get; set; }
        public int RoomId { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }

        public virtual GroupDTO Group { get; set; } = null!;
        public virtual RoomDTO Room { get; set; } = null!;
        public virtual TimeSlotDTO Slot { get; set; } = null!;
        public virtual ICollection<AttendanceDTO> Attendances { get; set; }
    }
}
