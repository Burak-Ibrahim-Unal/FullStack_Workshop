using Application.Features.Locations.Dtos;
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

    public class LocationRepository : EfRepositoryBase<Location, BaseDbContext>, ILocationRepository
    {
        public LocationRepository(BaseDbContext context) : base(context)
        {
        }

        /// <summary>
        /// This query brings all location records
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPaginate<LocationListDto>> GetAllLocations(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from location in Context.Locations

                         select new LocationListDto
                         {
                             Id = location.Id,
                             Latitude = location.Latitude,
                             Longitude = location.Longitude,
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }


        /// <summary>
        /// This query brings the location with id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<LocationDto?> GetLocationById(int id, CancellationToken cancellationToken = default)
        {
            var result = from location in Context.Locations
                         where location.Id == id

                         select new LocationDto
                         {
                             Id = location.Id,
                             Latitude = location.Latitude,
                             Longitude = location.Longitude,
                         };

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}