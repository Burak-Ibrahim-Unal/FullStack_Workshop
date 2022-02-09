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
        public async Task CarPlateCanNotBeDuplicatedWhenInserted(string plate)
        {
            var result = await _carRepository.GetListAsync(c => c.Plate == plate);

            if (result.Items.Any())
            {
                throw new BusinessException(Messages.CarPlateExists);
            }
        }


        public async Task CarCanNotBeEmptyWhenSelected(int id)
        {
            var result = await _carRepository.GetAsync(model => model.Id == id);

            if (result == null) throw new BusinessException(Messages.CarDoesNotExist);
        }


        public async Task ModelYearIsNotValid(short modelYear)
        {
            var result = await _carRepository.GetAsync(m => m.ModelYear == modelYear);

            if (result.ModelYear > (short)(DateTime.Now.Year + 1) || result.ModelYear < 1900)
            {
                throw new BusinessException(Messages.CarModelIsNotValid);
            }
        }



        public async Task CarCanNotBeRentWhenIsInMaintenance(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);

            if (car!.CarState == CarState.Maintenance) 
                throw new BusinessException(Messages.CarCanNotBeRentedWhenUnderMaintenance);
        }   
        
        

        public async Task CarCanNotBeRentWhenAlreadyRented(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);

            if (car!.CarState == CarState.Maintenance) 
                throw new BusinessException(Messages.CarCanNotBeRentedWhenAlreadyRented);
        }

        public async Task ChangeCarState(int id, CarState carstate)
        {
            var result = _carRepository.ChangeCarState(id, carstate);

            if (result == null)
            {
                throw new BusinessException(Messages.CarDoesNotExist);
            }
        }
    }


}

