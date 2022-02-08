using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.Enums;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class CarRepository : EfRepositoryBase<Car, BaseDbContext>, ICarRepository
    {
        public CarRepository(BaseDbContext context) : base(context)
        {


        }

        public bool ChangeCarState(int carId, CarState carState)
        {
            var result = Context.Cars.Where(c => c.Id == carId).FirstOrDefault();

            if (result == null)
            {
                return false;
            }

            result.CarState = carState;
            Context.Entry(result).Property(r => r.CarState).IsModified = true;
            Context.SaveChanges();
            return true;
        }
    }
}