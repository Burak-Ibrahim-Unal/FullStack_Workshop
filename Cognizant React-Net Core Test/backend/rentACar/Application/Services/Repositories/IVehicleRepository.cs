using Application.Features.Vehicles.Dtos;
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
    public interface IVehicleRepository : IAsyncRepository<Vehicle>, ISyncRepository<Vehicle>
    {
        Task<VehicleDto> GetVehicleById(int id, CancellationToken cancellationToken = default);

        Task<IPaginate<VehicleListDto>> GetAllVehicles(int index = 0, int size = 10, CancellationToken cancellationToken = default);


    }
}
