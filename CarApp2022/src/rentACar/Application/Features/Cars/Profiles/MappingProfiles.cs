using Application.Features.Cars.Commands;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, CarListDto>().ReverseMap();

            CreateMap<Car, CreateCarDto>()
                .ForMember(target => target.ColorName, opt => opt.MapFrom(source => source.Color.Name))
                .ForMember(target => target.ModelName, opt => opt.MapFrom(source => source.Model.Name))
                .ForMember(target => target.BrandName, opt => opt.MapFrom(source => source.Model.Brand.Name))
                .ReverseMap();

            CreateMap<Car, DeleteCarDto>()
                .ForMember(target => target.ModelName, opt => opt.MapFrom(source => source.Model.Name))
                .ForMember(target => target.BrandName, opt => opt.MapFrom(source => source.Model.Brand.Name))
                .ReverseMap();

            CreateMap<Car, UpdateCarDto>()
                .ForMember(target => target.ColorName, opt => opt.MapFrom(source => source.Color.Name))
                .ForMember(target => target.ModelName, opt => opt.MapFrom(source => source.Model.Name))
                .ForMember(target => target.BrandName, opt => opt.MapFrom(source => source.Model.Brand.Name))
                .ReverseMap();

            CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();


        }

    }
}
