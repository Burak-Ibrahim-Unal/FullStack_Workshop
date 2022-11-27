using Application.Features.Courses.Commands;
using Application.Features.Courses.Dtos;
using Application.Features.Courses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entites;

namespace Application.Features.Courses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CreateCourseCommand>().ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();
            CreateMap<Course, DeleteCourseCommand>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseListDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, DeleteCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();

            CreateMap<IPaginate<Course>, CourseListModel>().ReverseMap();


        }

    }
}
