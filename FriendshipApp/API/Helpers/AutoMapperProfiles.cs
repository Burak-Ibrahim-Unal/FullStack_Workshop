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
                       option => option.MapFrom(source => source.Photos.FirstOrDefault(photo => photo.IsMain).Url))
            .ForMember(destination => destination.Age,
                        target => target.MapFrom(source => source.Birthday.CalculateAge()));
            CreateMap<Photos, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Message, MessageDto>()
            .ForMember(destination => destination.SenderPhotoUrl,
                        option => option.MapFrom(source => source.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(destination => destination.RecipientPhotoUrl,
                        option => option.MapFrom(source => source.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));

        }
    }
}