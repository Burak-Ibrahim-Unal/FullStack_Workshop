using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class CreateCarCommand : IRequest<CreateCarDto>
    {
        public int WarehouseId { get; set; }
        public string? Location { get; set; }



        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;
            private readonly ICacheService _cacheService;

            public CreateCarCommandHandler(
                ICarRepository carRepository,
                IMapper mapper,
                CarBusinessRules carBusinessRules,
                ICacheService cacheService
            )
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
                _cacheService = cacheService;

            }


            /// <summary>
            /// If car is created,cache will ve removed...Create method handler... This method creates car
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<CreateCarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                Car mappedCar = _mapper.Map<Car>(request);
                Car createdCar = await _carRepository.AddAsync(mappedCar);

                _cacheService.Remove("cars-list", "cars-list-available");

                CreateCarDto carDtoToReturn = _mapper.Map<CreateCarDto>(createdCar);
                return carDtoToReturn;
            }

        }

    }
}
