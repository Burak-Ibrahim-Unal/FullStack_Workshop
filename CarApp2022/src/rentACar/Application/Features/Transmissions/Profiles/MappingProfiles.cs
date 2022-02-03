using Application.Features.Transmissions.Commands.CreateTransmission;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Models;
using Application.Features.Models.Commands.CreateModel;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, TransmissionListDto>().ReverseMap();
            CreateMap<IPaginate<Transmission>, TransmissionListModel>().ReverseMap();


        }

    }
}
