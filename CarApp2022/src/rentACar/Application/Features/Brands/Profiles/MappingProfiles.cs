using Application.Features.Brands.Commands;
using Application.Features.Brands.Commands;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<Brand, BrandDeleteDto>().ReverseMap();
            CreateMap<Brand, BrandUpdateDto>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();


        }

    }
}
