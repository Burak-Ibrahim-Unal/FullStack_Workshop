using Application.Features.Activities.Commands;
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
        }
    }
}