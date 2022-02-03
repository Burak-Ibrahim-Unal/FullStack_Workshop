using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        //Gerkhin dili 
        public async Task CarNameCanNotBeDuplicatedWhenInserted(string plate)
        {
            var result = await _carRepository.GetListAsync(b => b.Plate == plate);

            if (result.Items.Any())
            {
                throw new BusinessException("car Plate exists");
            }
        }

        public async Task ColorIsExist(int colorId)
        {
            var result = await _carRepository.GetListAsync(m => m.ColorId == colorId);

            if (result == null)
            {
                throw new BusinessException("Car ColorId dosent exist");
            }
        }
        public async Task ModelIsExist(int modelId)
        {
            var result = await _carRepository.GetListAsync(m => m.ModelId == modelId);

            if (result == null)
            {
                throw new BusinessException("Car ModelId dosent exist");
            }
        }
        public async Task ModelYearIsExist(short modelYear)
        {
            var result = await _carRepository.GetListAsync(m => m.ModelYear == modelYear);

            if (result == null)
            {
                throw new BusinessException("Car ModelYear dosent exist");
            }
        }
    }


}

