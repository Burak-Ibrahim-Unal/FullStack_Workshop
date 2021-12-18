using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(destination => destination.PhotoUrl,
                       option => option.MapFrom(target => target.Photos.FirstOrDefault(photo => photo.IsMain).Url));
            CreateMap<Photos, PhotoDto>();
        }
    }
}