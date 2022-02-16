using Application.Features.Cars.Dtos;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface ICarRepository : IAsyncRepository<Car>, ISyncRepository<Car>
    {
        bool CheckCarState(int carId, CarState carState);
        Task<IPaginate<CarListDto>> GetCars(int index = 0, int size = 10, CancellationToken cancellationToken = default);
        Task<IPaginate<CarListDto>> GetRentableCars(int index = 0, int size = 10, CancellationToken cancellationToken = default);
        Task<IPaginate<CarListDto>> GetCarsByCity(City city, int index = 0, int size = 10, CancellationToken cancellationToken = default);
    }
}
