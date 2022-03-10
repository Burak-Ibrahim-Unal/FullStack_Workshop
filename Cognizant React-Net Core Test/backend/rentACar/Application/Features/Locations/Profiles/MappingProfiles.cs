using Application.Features.Locations.Commands;
using Application.Features.Locations.Dtos;
using Application.Features.Locations.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Location, CreateLocationCommand>().ReverseMap();
            CreateMap<Location, DeleteLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateLocationCommand>().ReverseMap();

            CreateMap<Location, LocationListDto>().ReverseMap();
            CreateMap<Location, CreateLocationDto>().ReverseMap();
            CreateMap<Location, DeleteLocationDto>().ReverseMap();
            CreateMap<Location, UpdateLocationDto>().ReverseMap();

            CreateMap<Location, LocationListDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<IPaginate<Location>, LocationListModel>().ReverseMap();

            CreateMap<LocationDto, DeleteLocationDto>().ReverseMap();
            CreateMap<IPaginate<LocationListDto>, LocationListModel>().ReverseMap();
            CreateMap<IPaginate<LocationDto>, LocationListModel>().ReverseMap();


        }

    }
}
