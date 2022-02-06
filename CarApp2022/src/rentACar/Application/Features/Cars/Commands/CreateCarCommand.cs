﻿using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class CreateCarCommand : IRequest<CarCreateDto>
    {
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }


        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarCreateDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;

            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<CarCreateDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRules.CarPlateCanNotBeDuplicatedWhenInserted(request.Plate);
                await _carBusinessRules.ModelYearIsNotValid(request.ModelYear);

                var mappedCar = _mapper.Map<Car>(request);
                var createdCar = await _carRepository.AddAsync(mappedCar);
                var carDtoToReturn = _mapper.Map<CarCreateDto>(createdCar);
                return carDtoToReturn;
            }

        }

    }
}
