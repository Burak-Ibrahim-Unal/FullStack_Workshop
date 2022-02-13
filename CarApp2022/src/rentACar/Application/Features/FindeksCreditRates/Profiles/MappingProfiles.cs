using Application.Features.FindeksCreditRates.Commands;
using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.FindeksCreditRates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FindeksCreditRate, CreateFindeksCreditRateCommand>().ReverseMap();
        CreateMap<FindeksCreditRate, CreateFindeksCreditRateDto>().ReverseMap();
        CreateMap<FindeksCreditRate, UpdateFindeksCreditRateCommand>().ReverseMap();
        CreateMap<FindeksCreditRate, UpdateFindeksCreditRateDto>().ReverseMap();
        CreateMap<FindeksCreditRate, UpdateFindeksCreditRateFromServiceCommand>().ReverseMap();
        CreateMap<FindeksCreditRate, DeleteFindeksCreditRateCommand>().ReverseMap();
        CreateMap<FindeksCreditRate, DeleteFindeksCreditRateDto>().ReverseMap();
        CreateMap<FindeksCreditRate, FindeksCreditRateDto>().ReverseMap();
        CreateMap<FindeksCreditRate, FindeksCreditRateListDto>().ReverseMap();
        CreateMap<IPaginate<FindeksCreditRate>, FindeksCreditRateListModel>().ReverseMap();
    }
}