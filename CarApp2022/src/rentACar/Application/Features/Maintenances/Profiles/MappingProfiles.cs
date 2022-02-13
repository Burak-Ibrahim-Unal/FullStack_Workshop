using Application.Features.Maintenances.Commands;
using Application.Features.Maintenances.Dtos;
using Application.Features.Maintenances.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Maintenance, CreateMaintenanceCommand>().ReverseMap();
            CreateMap<Maintenance, UpdateMaintenanceCommand>().ReverseMap();
            CreateMap<Maintenance, MaintenanceListDto>().ReverseMap();
            CreateMap<Maintenance, CreateMaintenanceDto>().ReverseMap();
            CreateMap<Maintenance, UpdateMaintenanceDto>().ReverseMap();
            CreateMap<Maintenance, DeleteMaintenanceDto>().ReverseMap();
            CreateMap<IPaginate<Maintenance>, MaintenanceListModel>().ReverseMap();

        }
    }
}