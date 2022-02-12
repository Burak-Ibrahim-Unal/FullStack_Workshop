using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        private readonly ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        //Gerkhin 
        public async Task CheckCarByPlate(string plate)
        {
            var result = await _carRepository.GetListAsync(c => c.Plate == plate);

            if (result.Items.Any()) throw new BusinessException(Messages.CarPlateExists);
        }


        public async Task CheckCarById(int id)
        {
            var result = await _carRepository.GetAsync(car => car.Id == id);

            if (result == null) throw new BusinessException(Messages.CarDoesNotExist);
        }


        public async Task CheckCarByModelYear(short modelYear)
        {
            var result = await _carRepository.GetAsync(m => m.ModelYear == modelYear);

            if (result.ModelYear > (short)(DateTime.Now.Year + 1) || result.ModelYear < 1900)
            {
                throw new BusinessException(Messages.CarModelIsNotValid);
            }
        }



        public async Task CheckCarByMaintenanceStatus(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);

            if (car!.CarState == CarState.Maintenance)  
                throw new BusinessException(Messages.CarCanNotBeRentedWhenUnderMaintenance);
        }   
        
        

        public async Task CheckCarByRentStatus(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);

            if (car!.CarState == CarState.Maintenance) 
                throw new BusinessException(Messages.CarCanNotBeRentedWhenAlreadyRented);
        }

        public async Task CheckCarState(int id, CarState carstate)
        {
            var result = _carRepository.CheckCarState(id, carstate);

            if (result == null)
                throw new BusinessException(Messages.CarDoesNotExist);
        }
    }


}

