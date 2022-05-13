using System.Linq;
using Application.Features.Activities.Commands;
using Application.Features.Activities.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Activities.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>().ReverseMap();
            CreateMap<Activity, ActivityDto>()
                .ForMember(d => d.HostUsername, o => o.MapFrom(a => a.Attendees
                    .FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, Application.Profiles.Profile>()
                .ForMember(d => d.Username, o => o.MapFrom(a => a.AppUser.UserName))
                .ForMember(d => d.DisplayName, o => o.MapFrom(a => a.AppUser.DisplayName))
                .ForMember(d => d.Bio, o => o.MapFrom(a => a.AppUser.Bio));

            CreateMap<AppUser, Application.Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));


        }
    }
}