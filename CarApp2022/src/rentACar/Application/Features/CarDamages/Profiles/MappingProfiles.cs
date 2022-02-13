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
            .ForMember(createdCarDamageDto => createdCarDamageDto.CarModelBrandName, opt => opt.MapFrom(cardamage => cardamage.Car.Model.Brand.Name))
            .ForMember(createdCarDamageDto => createdCarDamageDto.CarModelName, 
                    opt => opt.MapFrom(carDamage => carDamage.Car.Model.Name))
            .ForMember(createdCarDamageDto => createdCarDamageDto.CarModelYear,
                    opt => opt.MapFrom(carDamage => carDamage.Car.ModelYear))
            .ForMember(createdCarDamageDto => createdCarDamageDto.CarPlate, 
                    opt => opt.MapFrom(carDamage => carDamage.Car.Plate))
            .ReverseMap();

        CreateMap<CarDamage, UpdateCarDamageCommand>().ReverseMap();
        CreateMap<CarDamage, UpdateCarDamageDto>()
            .ForMember(UpdateCarDamageDto => UpdateCarDamageDto.CarModelBrandName, 
                opt => opt.MapFrom(c => c.Car.Model.Brand.Name))
            .ForMember(UpdateCarDamageDto => UpdateCarDamageDto.CarModelName, 
                opt => opt.MapFrom(c => c.Car.Model.Name))
            .ForMember(UpdateCarDamageDto => UpdateCarDamageDto.CarModelYear, 
                opt => opt.MapFrom(c => c.Car.ModelYear))
            .ForMember(UpdateCarDamageDto => UpdateCarDamageDto.CarPlate, 
                opt => opt.MapFrom(c => c.Car.Plate))
            .ReverseMap();

        CreateMap<CarDamage, DeleteCarDamageCommand>().ReverseMap();

        CreateMap<CarDamage, DeleteCarDamageDto>()
            .ForMember(DeleteCarDamageDto => DeleteCarDamageDto.CarModelBrandName, 
                opt => opt.MapFrom(carDamage => carDamage.Car.Model.Brand.Name))
            .ForMember(DeleteCarDamageDto => DeleteCarDamageDto.CarModelName, 
                opt => opt.MapFrom(carDamage => carDamage.Car.Model.Name))
            .ReverseMap();

        CreateMap<CarDamage, CarDamageDto>()
            .ForMember(CarDamageDto => CarDamageDto.CarModelBrandName,
                opt => opt.MapFrom(carDamage => carDamage.Car.Model.Brand.Name))
            .ForMember(CarDamageDto => CarDamageDto.CarModelName, 
                opt => opt.MapFrom(carDamage => carDamage.Car.Model.Name))
            .ForMember(CarDamageDto => CarDamageDto.CarModelYear, 
                opt => opt.MapFrom(carDamage => carDamage.Car.ModelYear))
            .ForMember(CarDamageDto => CarDamageDto.CarPlate,
                opt => opt.MapFrom(carDamage => carDamage.Car.Plate))
            .ReverseMap();

        CreateMap<CarDamage, CarDamageListDto>()
            .ForMember(CarDamageListDto => CarDamageListDto.CarModelBrandName,
                opt => opt.MapFrom(c => c.Car.Model.Brand.Name))
            .ForMember(CarDamageListDto => CarDamageListDto.CarModelName, opt => opt.MapFrom(c => c.Car.Model.Name))
            .ForMember(CarDamageListDto => CarDamageListDto.CarModelYear, opt => opt.MapFrom(c => c.Car.ModelYear))
            .ForMember(CarDamageListDto => CarDamageListDto.CarPlate, opt => opt.MapFrom(c => c.Car.Plate))
            .ReverseMap();

        CreateMap<IPaginate<CarDamage>, CarDamageListModel>().ReverseMap();
    }
}