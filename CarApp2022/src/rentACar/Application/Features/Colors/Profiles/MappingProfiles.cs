using Application.Features.Colors.Commands;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
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
            CreateMap<Color, CreateFuelCommand>().ReverseMap();
            CreateMap<Color, UpdateFuelCommand>().ReverseMap();
            CreateMap<Color, FuelListDto>().ReverseMap();
            CreateMap<Color, FuelCreateDto>().ReverseMap();
            CreateMap<Color, FuelDeleteDto>().ReverseMap();
            CreateMap<Color, FuelUpdateDto>().ReverseMap();
            CreateMap<IPaginate<Color>, ColorListModel>().ReverseMap();

        }

    }
}
