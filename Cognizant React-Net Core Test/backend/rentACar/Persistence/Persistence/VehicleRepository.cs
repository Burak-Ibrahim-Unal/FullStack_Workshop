using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class VehicleRepository : EfRepositoryBase<Vehicle, BaseDbContext>, IVehicleRepository
    {
        public VehicleRepository(BaseDbContext context) : base(context)
        {
        }

        /// <summary>
        /// This query brings all vehicle records
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPaginate<VehicleListDto>> GetAllVehicles(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from vehicle in Context.Vehicles
                         join car in Context.Cars
                         on vehicle.CarId equals car.Id
                         join warehouse in Context.Warehouses
                         on car.WarehouseId equals warehouse.Id
                         join location in Context.Locations
                         on warehouse.LocationId equals location.Id

                         orderby vehicle.DateAdded ascending

                         select new VehicleListDto
                         {
                             Id = vehicle.Id,
                             Make = vehicle.Make,
                             Model = vehicle.Model,
                             YearModel = vehicle.YearModel,
                             Price = vehicle.Price,
                             Licensed = vehicle.Licensed,
                             DateAdded = vehicle.DateAdded,
                             Location = car.Location,
                             WarehouseLatitude = location.Latitude,
                             WarehouseLongitude = location.Longitude,
                             WarehouseName = warehouse.Name,

                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }


        /// <summary>
        /// This query brings the vehicle with id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<VehicleDto?> GetVehicleById(int id, CancellationToken cancellationToken = default)
        {
            var result = from vehicle in Context.Vehicles
                         join car in Context.Cars
                         on vehicle.CarId equals car.Id
                         join warehouse in Context.Warehouses
                         on car.WarehouseId equals warehouse.Id
                         join location in Context.Locations
                         on warehouse.LocationId equals location.Id

                         where vehicle.Id == id
                         orderby vehicle.DateAdded ascending

                         select new VehicleDto
                         {
                             Id = vehicle.Id,
                             Make = vehicle.Make,
                             Model = vehicle.Model,
                             YearModel = vehicle.YearModel,
                             Price = vehicle.Price,
                             Licensed = vehicle.Licensed,
                             DateAdded = vehicle.DateAdded,
                             Location = car.Location,
                             WarehouseLatitude = location.Latitude,
                             WarehouseLongitude = location.Longitude,
                             WarehouseName = warehouse.Name,

                         };

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}