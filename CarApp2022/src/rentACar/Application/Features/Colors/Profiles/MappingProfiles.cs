using Application.Features.Colors.Commands.CreateColor;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using Application.Features.Models.Commands.CreateModel;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Color, CreateColorCommand>().ReverseMap();
            CreateMap<Color, ColorListDto>().ReverseMap();
            CreateMap<IPaginate<Color>, ColorListModel>().ReverseMap();


        }

    }
}
