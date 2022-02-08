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
            CreateMap<Maintenance, MaintenanceCreateDto>().ReverseMap();
            CreateMap<Maintenance, MaintenanceUpdateDto>().ReverseMap();
            CreateMap<Maintenance, MaintenanceDeleteDto>().ReverseMap();
            CreateMap<IPaginate<Maintenance>, MaintenanceListModel>().ReverseMap();

        }
    }
}