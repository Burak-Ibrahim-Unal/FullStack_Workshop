using Application.Features.Activities.Commands;
using Application.Features.Activities.Dto;
using AutoMapper;
using Domain.Entities;
using static Application.Features.Activities.Commands.EditActivityCommand;

namespace Application.Features.Activities.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
        }
    }
}