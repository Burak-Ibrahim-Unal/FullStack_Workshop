using Application.Features.Models.Commands;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, ModelListDto>().ReverseMap();

            CreateMap<Model, CreateModelDto>()
                .ForMember(target => target.BrandName, opt => opt.MapFrom(destination => destination.Brand.Name))
                .ForMember(target => target.TransmissionName, 
                    opt => opt.MapFrom(destination => destination.Transmission.Name))
                .ForMember(target => target.FuelName, opt => opt.MapFrom(destination => destination.Fuel.Name))
                .ReverseMap();

            CreateMap<Model, UpdateModelDto>()
                .ForMember(target => target.BrandName, opt => opt.MapFrom(destination => destination.Brand.Name))
                .ForMember(target => target.TransmissionName,
                    opt => opt.MapFrom(destination => destination.Transmission.Name))
                .ForMember(target => target.FuelName, opt => opt.MapFrom(destination => destination.Fuel.Name))
                .ReverseMap();

            CreateMap<Model, DeleteModelDto>().ReverseMap();
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

        }

    }
}
