using Application.Features.Colors.Commands;
using Application.Features.Colors.Dtos;
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
            CreateMap<Model, CreateColorCommand>().ReverseMap();
            CreateMap<Model, UpdateColorCommand>().ReverseMap();
            CreateMap<Model, ModelListDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

        }

    }
}
