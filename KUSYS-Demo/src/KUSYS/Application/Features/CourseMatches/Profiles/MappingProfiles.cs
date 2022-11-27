using Application.Features.CourseMatches.Commands;
using Application.Features.CourseMatches.Dtos;
using Application.Features.CourseMatches.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entites;

namespace Application.Features.CourseMatches.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CourseMatch, CreateCourseMatchCommand>().ReverseMap();
            CreateMap<CourseMatch, UpdateCourseMatchCommand>().ReverseMap();
            CreateMap<CourseMatch, DeleteCourseMatchCommand>().ReverseMap();

            CreateMap<CourseMatch, CourseMatchDto>().ReverseMap();
            CreateMap<CourseMatch, CourseMatchListDto>().ReverseMap();
            CreateMap<CourseMatch, CreateCourseMatchDto>().ReverseMap();
            CreateMap<CourseMatch, DeleteCourseMatchDto>().ReverseMap();
            CreateMap<CourseMatch, UpdateCourseMatchDto>().ReverseMap();

            CreateMap<IPaginate<CourseMatch>, CourseMatchListModel>().ReverseMap();
            CreateMap<IPaginate<CourseMatchListDto>, CourseMatchListModel>().ReverseMap();
            CreateMap<IPaginate<CourseMatchDto>, CourseMatchListModel>().ReverseMap();


        }

    }
}
