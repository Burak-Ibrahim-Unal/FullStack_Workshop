using Application.Features.Cars.Dtos;
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

    public class CarRepository : EfRepositoryBase<Car, BaseDbContext>, ICarRepository
    {
        public CarRepository(BaseDbContext context) : base(context)
        {
        }

        /// <summary>
        /// This query brings all car records
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPaginate<CarListDto>> GetAllCars(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars

                         select new CarListDto
                         {
                             Id = car.Id,
                             Location = car.Location,
                             WarehouseName = car.Warehouse.Name
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }


        /// <summary>
        /// This query brings the car with id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CarDto?> GetCarById(int id, CancellationToken cancellationToken = default)
        {
            var result = from car in Context.Cars
                         where car.Id == id

                         select new CarDto
                         {
                             Id = car.Id,
                             Location = car.Location,
                             WarehouseName = car.Warehouse.Name
                         };

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}