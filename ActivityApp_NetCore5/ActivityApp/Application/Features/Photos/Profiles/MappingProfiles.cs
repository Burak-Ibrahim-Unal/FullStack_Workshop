using System.Linq;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Photos.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<AppUser, Application.Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));


        }
    }
}