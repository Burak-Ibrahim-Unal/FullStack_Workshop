using Application.Features.Cars.Dtos;
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
    public interface ICarRepository : IAsyncRepository<Car>, ISyncRepository<Car>
    {
        Task<CarDto> GetCarById(int id, CancellationToken cancellationToken = default);

        Task<IPaginate<CarListDto>> GetAllCars(int index = 0, int size = 10, CancellationToken cancellationToken = default);

        //Task<IPaginate<CarListDto>> GetAllCarsByAvailable(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);

        //Task<IPaginate<CarListDto>> GetAllCarsByNotAvailable(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);

        //Task<IPaginate<CarListDto>> GetAllCarsByRented(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);    

        //Task<IPaginate<CarListDto>> GetAllCarsByUnderMaintenance(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);

        //Task<IPaginate<CarListDto>> GetAllCarsByCity(Expression<Func<Car, bool>> predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);

    }
}
