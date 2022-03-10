using Application.Features.Locations.Dtos;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface ILocationRepository : IAsyncRepository<Location>, ISyncRepository<Location>
    {
        Task<LocationDto> GetLocationById(int id, CancellationToken cancellationToken = default);

        Task<IPaginate<LocationListDto>> GetAllLocations(int index = 0, int size = 10, CancellationToken cancellationToken = default);


    }
}
