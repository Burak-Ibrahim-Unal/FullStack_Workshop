using Application.Features.Cars.Dtos;
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
    public class UpdateCarCommand : IRequest<UpdateCarDto>
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string? Location { get; set; }



        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarDto>
        {
            private ICarRepository _carRepository;
            private IMapper _mapper;
            private CarBusinessRules _carBusinessRules;
            private readonly ICacheService _cacheService;


            public UpdateCarCommandHandler(
                CarBusinessRules carBusinessRules,
                ICarRepository carRepository,
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _carBusinessRules = carBusinessRules;
                _carRepository = carRepository;
                _mapper = mapper;
                _cacheService= cacheService;
            }

            /// <summary>
            /// If car is update,cache will ve removed...Update method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<UpdateCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var updateCarDto = await _carRepository.GetCarById(request.Id);

                if (updateCarDto == null) throw new BusinessException(Messages.CarDoesNotExist);

                Car carToUpdate = _mapper.Map<Car>(request);

                await _carRepository.UpdateAsync(carToUpdate);

                _cacheService.Remove("cars-list", "cars-list-available", "cars-list-not-available", "cars-list-rented", "cars-list-under-maintenance");

                UpdateCarDto updatedCarDto = _mapper.Map<UpdateCarDto>(carToUpdate);
                return updatedCarDto;
            }

        }

    }
}
