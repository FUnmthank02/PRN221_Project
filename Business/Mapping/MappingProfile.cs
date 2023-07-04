using PRN221_Project.Business.DTO;
using PRN221_Project.DataAccess.Models;

namespace PRN221_Project.Business.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Session, SessionDTO>();
            CreateMap<Group, GroupDTO>();
            CreateMap<TimeSlot, TimeSlotDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<Lecture, LectureDTO>();
            CreateMap<Attendance, AttendanceDTO>();
            CreateMap<AttendanceDTO, Attendance>();
            CreateMap<Enroll, EnrollDTO>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
