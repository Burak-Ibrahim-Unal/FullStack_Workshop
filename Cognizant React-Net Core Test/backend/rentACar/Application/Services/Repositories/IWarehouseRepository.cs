using Application.Features.Warehouses.Dtos;
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
    public interface IWarehouseRepository : IAsyncRepository<Warehouse>, ISyncRepository<Warehouse>
    {
        Task<WarehouseDto> GetWarehouseById(int id, CancellationToken cancellationToken = default);

        Task<IPaginate<WarehouseListDto>> GetAllWarehouses(int index = 0, int size = 10, CancellationToken cancellationToken = default);


    }
}
