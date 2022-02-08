using Application.Features.Fuels.Commands;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using Application.Features.Models.Commands;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
            CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
            CreateMap<Fuel, FuelListDto>().ReverseMap();
            CreateMap<Fuel, FuelCreateDto>().ReverseMap();
            CreateMap<Fuel, FuelDeleteDto>().ReverseMap();
            CreateMap<Fuel, FuelUpdateDto>().ReverseMap();
            CreateMap<IPaginate<Fuel>, FuelListModel>().ReverseMap();


        }

    }
}
