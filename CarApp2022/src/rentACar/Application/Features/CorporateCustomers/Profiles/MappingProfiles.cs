using Application.Features.CorporateCustomers.Commands;
using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, CorporateCustomerListDto>().ReverseMap();
        CreateMap<CorporateCustomer, CreateCorporateCustomerDto>().ReverseMap();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerDto>().ReverseMap();
        CreateMap<CorporateCustomer, DeleteCorporateCustomerDto>().ReverseMap();
        CreateMap<IPaginate<CorporateCustomer>, CorporateCustomerListModel>().ReverseMap();
    }
}