using Application.Features.Rentals.Commands;
using Application.Features.Rentals.Dtos;
using Application.Features.Rentals.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Rentals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Rental, CreateRentalCommand>().ReverseMap();
            CreateMap<Rental, UpdateRentalCommand>().ReverseMap();
            CreateMap<Rental, RentalListDto>().ReverseMap();
            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<Rental, DeleteRentalDto>().ReverseMap();
            CreateMap<Rental, UpdateRentalDto>().ReverseMap();
            CreateMap<IPaginate<Rental>, RentalListModel>().ReverseMap();

            //CreateMap<Rental, RentalListDto>()
            //.ForMember(r => r.CarModelRentalName, opt => opt.MapFrom(r => r.Car.Model.Rental.Name))
            //.ForMember(r => r.CarModelName, opt => opt.MapFrom(r => r.Car.Model.Name))
            //.ForMember(r => r.CarColorName, opt => opt.MapFrom(r => r.Car.Color.Name))
            //.ForMember(r => r.CarModelYear, opt => opt.MapFrom(r => r.Car.ModelYear))
            //.ForMember(r => r.CarPlate, opt => opt.MapFrom(r => r.Car.Plate)).ForMember(r => r.CustomerFullName,
            //    opt => opt.MapFrom(
            //        r =>
            //            r.Customer.IndividualCustomer != null
            //                ? $"{r.Customer.IndividualCustomer.FirstName} {r.Customer.IndividualCustomer.FirstName}"
            //                : r.Customer.CorporateCustomer.CompanyName))
            //.ForMember(r => r.CustomerMail, opt => opt.MapFrom(r => r.Customer.Email));


        }

    }
}
