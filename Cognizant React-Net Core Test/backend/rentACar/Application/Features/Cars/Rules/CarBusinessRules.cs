using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
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


        public async Task CheckCarDtoisNull(CarDto carDto)
        {
            if (carDto == null) throw new BusinessException(Messages.CarDoesNotExist);
        }

    }


}

