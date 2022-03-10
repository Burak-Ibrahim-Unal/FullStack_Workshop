using Application.Features.Warehouses.Dtos;
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

    public class WarehouseRepository : EfRepositoryBase<Warehouse, BaseDbContext>, IWarehouseRepository
    {
        public WarehouseRepository(BaseDbContext context) : base(context)
        {
        }

        /// <summary>
        /// This query brings all warehouse records
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPaginate<WarehouseListDto>> GetAllWarehouses(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from warehouse in Context.Warehouses
                         join location in Context.Locations
                         on warehouse.LocationId equals location.Id

                         select new WarehouseListDto
                         {
                             Id = warehouse.Id,
                             Name = warehouse.Name,
                             Longitude = location.Longitude,
                             Latitude = location.Latitude,

                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }


        /// <summary>
        /// This query brings the warehouse with id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<WarehouseDto?> GetWarehouseById(int id, CancellationToken cancellationToken = default)
        {
            var result = from warehouse in Context.Warehouses
                         join location in Context.Locations
                         on warehouse.LocationId equals location.Id

                         select new WarehouseDto
                         {
                             Id = id,
                             Name = warehouse.Name,
                             Longitude = location.Longitude,
                             Latitude = location.Latitude,

                         };

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}