using Application.Features.IndividualCustomers.Commands;
using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();
        CreateMap<IndividualCustomer, IndividualCustomerListDto>().ReverseMap();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerDto>().ReverseMap();
        CreateMap<IndividualCustomer, CreateIndividualCustomerDto>().ReverseMap();
        CreateMap<IndividualCustomer, DeleteIndividualCustomerDto>().ReverseMap();
        CreateMap<IPaginate<IndividualCustomer>, IndividualCustomerListModel>().ReverseMap();
    }
}