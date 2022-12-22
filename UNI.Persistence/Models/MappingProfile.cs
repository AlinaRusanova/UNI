using AutoMapper;
using UNI.Domain.Entities;

namespace UNI.Persistence.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
        }
    }
}
