﻿using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class DeleteCarCommand : IRequest<DeleteCarDto>
    {
        public int Id { get; set; }


        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarDto> // sizin kodlaru merak ettim şu anda :)
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly ICacheService _cacheService;

            public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, ICacheService cacheService)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            public async Task<DeleteCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                #region V1
                // To return deleted car

                var deletedCarDto = await _carRepository.GetCarById(request.Id);

                if (deletedCarDto == null) throw new BusinessException(Messages.CarDoesNotExist);

                var carToDelete = _mapper.Map<Car>(request);
                await _carRepository.DeleteAsync(carToDelete);
                _cacheService.Remove("cars-list");

                DeleteCarDto returnToDeletedCarDto = _mapper.Map<DeleteCarDto>(deletedCarDto);
                return returnToDeletedCarDto;
                #endregion

                #region Ahmet

                //Car carToDelete = await _carRepository.GetAsync(car => car.Id == request.Id);

                //if (carToDelete is null) throw new BusinessException(Messages.CarDoesNotExist);
                //Car mappedCar = _mapper.Map<Car>(request);
                //Car deletedCar = await _carRepository.DeleteAsync(mappedCar);
                //_cacheService.Remove("cars-list");
                //DeleteCarDto deletedCarDto = _mapper.Map<DeleteCarDto>(deletedCar);
                //return deletedCarDto;  
                #endregion

            }

        }

    }
}
