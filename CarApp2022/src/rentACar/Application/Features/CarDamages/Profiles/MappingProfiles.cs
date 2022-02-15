using Application.Features.CarDamages.Commands;
using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.CarDamages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CarDamage, CreateCarDamageCommand>().ReverseMap();

        CreateMap<CarDamage, CreateCarDamageDto>()
            .ForMember(target => target.CarModelBrandName,
                    opt => opt.MapFrom(source => source.Car.Model.Brand.Name))
            .ForMember(target => target.CarModelName,
                    opt => opt.MapFrom(source => source.Car.Model.Name))
            .ForMember(target => target.CarModelYear,
                    opt => opt.MapFrom(source => source.Car.ModelYear))
            .ForMember(target => target.CarPlate,
                    opt => opt.MapFrom(source => source.Car.Plate))
            .ReverseMap();

        CreateMap<CarDamage, UpdateCarDamageCommand>().ReverseMap();

        CreateMap<CarDamage, UpdateCarDamageDto>()
            .ForMember(target => target.CarModelBrandName,
                opt => opt.MapFrom(source => source.Car.Model.Brand.Name))
            .ForMember(target => target.CarModelName,
                opt => opt.MapFrom(source => source.Car.Model.Name))
            .ForMember(target => target.CarModelYear,
                opt => opt.MapFrom(source => source.Car.ModelYear))
            .ForMember(target => target.CarPlate,
                opt => opt.MapFrom(source => source.Car.Plate))
            .ReverseMap();

        CreateMap<CarDamage, DeleteCarDamageCommand>().ReverseMap();

        CreateMap<CarDamage, DeleteCarDamageDto>()
            .ForMember(target => target.CarModelBrandName,
                opt => opt.MapFrom(source => source.Car.Model.Brand.Name))
            .ForMember(target => target.CarModelName,
                opt => opt.MapFrom(source => source.Car.Model.Name))
            .ReverseMap();

        CreateMap<CarDamage, CarDamageDto>().ReverseMap();

        CreateMap<CarDamage, CarDamageListDto>()
            .ForMember(target => target.CarModelBrandName,
                opt => opt.MapFrom(c => c.Car.Model.Brand.Name))
            .ForMember(target => target.CarModelName, opt => opt.MapFrom(source => source.Car.Model.Name))
            .ForMember(target => target.CarModelYear, opt => opt.MapFrom(source => source.Car.ModelYear))
            .ForMember(target => target.CarPlate, opt => opt.MapFrom(source => source.Car.Plate))
            .ReverseMap();


        CreateMap<IPaginate<CarDamage>, CarDamageListModel>().ReverseMap();
    }
}