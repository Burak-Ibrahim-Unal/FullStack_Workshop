using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.Enums;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class CarRepository : EfRepositoryBase<Car, BaseDbContext>, ICarRepository
    {
        public CarRepository(BaseDbContext context) : base(context)
        {
        }

        public bool CheckCarState(int carId, CarState carState)
        {
            var result = Context.Cars.Where(c => c.Id == carId).FirstOrDefault();

            if (result == null) return false;

            result.CarState = carState;
            Context.Entry(result).Property(r => r.CarState).IsModified = true;
            Context.SaveChanges();
            return true;
        }

        public Task<CarDto?> GetCarById(int id, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id

                         where car.Id == id

                         select new CarDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             Plate = car.Plate,
                         };

            return Task.FromResult(result.FirstOrDefault());

        }

        public async Task<IPaginate<CarListDto>> GetAllCars(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id


                         select new CarListDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             ImageUrl = model.ImageUrl
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);

        }

        public Task<IPaginate<CarListDto>> GetCarsByCity(City city, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IPaginate<CarListDto>> GetRentableCars(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


        public async Task<IPaginate<CarListDto>> GetAllCarsByAvailable(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id

                         where car.CarState == CarState.Available


                         select new CarListDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             ImageUrl = model.ImageUrl
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<CarListDto>> GetAllCarsByNotAvailable(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id

                         where car.CarState != CarState.Available


                         select new CarListDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             ImageUrl = model.ImageUrl
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<CarListDto>> GetAllCarsByCity(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id

                         where car.RentalOfficeId == rentaloffice.Id

                         select new CarListDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             ImageUrl = model.ImageUrl
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<CarListDto>> GetAllCarsByRented(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id

                         where car.CarState == CarState.Rented


                         select new CarListDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             ImageUrl = model.ImageUrl
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<CarListDto>> GetAllCarsByUnderMaintenance(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         join model in Context.Models
                         on car.ModelId equals model.Id
                         join color in Context.Colors
                         on car.ColorId equals color.Id
                         join brand in Context.Brands
                         on model.BrandId equals brand.Id
                         join rentaloffice in Context.RentalOffices
                         on car.RentalOfficeId equals rentaloffice.Id
                         join district in Context.Districts
                         on rentaloffice.DistrictId equals district.Id
                         join province in Context.Provinces
                         on district.ProvinceId equals province.Id
                         join country in Context.Countries
                         on province.CountryId equals country.Id

                         where car.CarState == CarState.Maintenance


                         select new CarListDto
                         {
                             Id = car.Id,
                             Model = model.Name,
                             Color = color.Name,
                             RentalOfficeCountry = country.Name,
                             RentalOfficeCity = province.Name,
                             RentalOfficeBranch = district.Name,
                             ModelYear = car.ModelYear,
                             CarState = ((CarState)car.CarState).ToString(),
                             DailyPrice = model.DailyPrice,
                             Brand = brand.Name,
                             ImageUrl = model.ImageUrl
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }
    }
}