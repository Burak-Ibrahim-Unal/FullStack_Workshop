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
            CreateMap<Car, DeleteCarCommand>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, DeliverRentalCarCommand>().ReverseMap();
            CreateMap<Car, MaintainCarCommand>().ReverseMap();

            CreateMap<Car, CarListDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<Car, DeleteCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();
            CreateMap<Car, CarListDto>().ReverseMap();
            CreateMap<Car, CarDto>()
                .ForMember(target => target.Brand, opt => opt.MapFrom(source => source.Model.Brand.Name))
                .ForMember(target => target.Model, opt => opt.MapFrom(source => source.Model.Name))
                .ForMember(target => target.Color, opt => opt.MapFrom(source => source.Color.Name))
                .ReverseMap();

            CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();
            CreateMap<IPaginate<CarListDto>, CarListModel>().ReverseMap();
            CreateMap<IPaginate<CarDto>, CarListModel>().ReverseMap();



        }

    }
}
