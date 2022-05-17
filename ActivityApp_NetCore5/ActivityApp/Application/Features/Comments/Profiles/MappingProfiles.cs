using System.Linq;
using Application.Features.Comments.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Comments.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.Username, o => o.MapFrom(a => a.Author.UserName))
                .ForMember(d => d.DisplayName, o => o.MapFrom(a => a.Author.DisplayName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));

        }
    }
}