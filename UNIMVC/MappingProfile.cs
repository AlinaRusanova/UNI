using AutoMapper;
using UNI.Domain.Entities;
using UNI.Persistence.Models;

namespace UNI.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();

            CreateMap<Student, StudentModel>()
                 
                    .ForMember(dest => dest.GroupId,
                    opt => opt.MapFrom(src => src.Group.Id))
                    //.ForMember(dest => dest.GroupName,
                    // opt => opt.MapFrom(src => src.Group.GroupName))
                    .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.ContactInfo.Address))
                    .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.ContactInfo.Email))
                    .ForMember(dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.ContactInfo.PhoneNumber))
                    //.ForMember(dest => dest.UrlStudentPhoto,
                    //opt => opt.MapFrom(src => src.UrlStudentPhoto))
                    //.ForMember(dest => dest.ContactInfoId,
                    //opt => opt.MapFrom(src => src.ContactInfo.Id))
                    .ReverseMap();


        }
    }
}
