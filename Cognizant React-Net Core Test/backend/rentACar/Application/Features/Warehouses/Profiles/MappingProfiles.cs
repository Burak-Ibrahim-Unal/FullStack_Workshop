using Application.Features.Warehouses.Commands;
using Application.Features.Warehouses.Dtos;
using Application.Features.Warehouses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Warehouse, CreateWarehouseCommand>().ReverseMap();
            CreateMap<Warehouse, DeleteWarehouseCommand>().ReverseMap();
            CreateMap<Warehouse, UpdateWarehouseCommand>().ReverseMap();

            CreateMap<Warehouse, WarehouseListDto>().ReverseMap();
            CreateMap<Warehouse, CreateWarehouseDto>().ReverseMap();
            CreateMap<Warehouse, DeleteWarehouseDto>().ReverseMap();
            CreateMap<Warehouse, UpdateWarehouseDto>().ReverseMap();

            CreateMap<Warehouse, WarehouseListDto>().ReverseMap();
            CreateMap<Warehouse, WarehouseDto>().ReverseMap();
            CreateMap<IPaginate<Warehouse>, WarehouseListModel>().ReverseMap();

            CreateMap<WarehouseDto, DeleteWarehouseDto>().ReverseMap();
            CreateMap<IPaginate<WarehouseListDto>, WarehouseListModel>().ReverseMap();
            CreateMap<IPaginate<WarehouseDto>, WarehouseListModel>().ReverseMap();


        }

    }
}
