using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(destination => destination.PhotoUrl,
                       option => option.MapFrom(target => target.Photos.FirstOrDefault(photo => photo.IsMain).Url))
            .ForMember(destination => destination.Age, 
                        target => target.MapFrom(source => source.Birthday.CalculateAge()));
            CreateMap<Photos, PhotoDto>();
        }
    }
}