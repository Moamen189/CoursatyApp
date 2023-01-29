using AutoMapper;
using CoursatyApp.DTOs;
using CoursatyApp.Entities;

namespace CoursatyApp.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(dst => dst.Id, src => src.MapFrom(c => c.Id))
                .ForMember(dst => dst.Category, src => src.MapFrom(c => c.CategoryId))
                .ForMember(dst => dst.Creation, src => src.MapFrom(c => c.Creation_Date.ToShortDateString()));


        }
    }
}
