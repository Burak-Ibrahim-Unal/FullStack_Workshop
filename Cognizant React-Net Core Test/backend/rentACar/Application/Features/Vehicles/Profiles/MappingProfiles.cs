using Application.Features.Vehicles.Commands;
using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Vehicle, CreateVehicleCommand>().ReverseMap();
            CreateMap<Vehicle, DeleteVehicleCommand>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleCommand>().ReverseMap();

            CreateMap<Vehicle, CreateVehicleDto>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();

            CreateMap<Vehicle, DeleteVehicleDto>()
                .ForMember(target => target.WarehouseName, opt => opt.MapFrom(dest => dest.Car.Warehouse.Name))
                .ForMember(target => target.WarehouseLatitude, opt => opt.MapFrom(dest => dest.Car.Warehouse.Location.Latitude))
                .ForMember(target => target.WarehouseLongitude, opt => opt.MapFrom(dest => dest.Car.Warehouse.Location.Longitude))
                .ForMember(target => target.Location, opt => opt.MapFrom(dest => dest.Car.Location))
                .ReverseMap();


            CreateMap<Vehicle, VehicleListDto>()
                .ForMember(target => target.WarehouseName, opt => opt.MapFrom(dest => dest.Car.Warehouse.Name))
                .ForMember(target => target.WarehouseLatitude, opt => opt.MapFrom(dest => dest.Car.Warehouse.Location.Latitude))
                .ForMember(target => target.WarehouseLongitude, opt => opt.MapFrom(dest => dest.Car.Warehouse.Location.Longitude))
                .ForMember(target => target.Location, opt => opt.MapFrom(dest => dest.Car.Location))
                .ReverseMap();

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(target => target.WarehouseName, opt => opt.MapFrom(dest => dest.Car.Warehouse.Name))
                .ForMember(target => target.WarehouseLatitude, opt => opt.MapFrom(dest => dest.Car.Warehouse.Location.Latitude))
                .ForMember(target => target.WarehouseLongitude, opt => opt.MapFrom(dest => dest.Car.Warehouse.Location.Longitude))
                .ForMember(target => target.Location, opt => opt.MapFrom(dest => dest.Car.Location))
                .ReverseMap();

            CreateMap<IPaginate<Vehicle>, VehicleListModel>().ReverseMap();
            CreateMap<VehicleDto, DeleteVehicleDto>().ReverseMap();
            CreateMap<IPaginate<VehicleListDto>, VehicleListModel>().ReverseMap();
            CreateMap<IPaginate<VehicleDto>, VehicleListModel>().ReverseMap();


        }

    }
}
