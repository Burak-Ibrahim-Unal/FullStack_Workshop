using Application.Features.Cars.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarService
{
    public interface ICarService
    {
        public Task<Car> GetById(int Id);
        public Task<Car> PickUpCar(Rental rental);
    }
}
