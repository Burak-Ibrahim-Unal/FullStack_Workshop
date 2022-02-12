﻿using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
        public int Kilometer { get; set; }
        public short MinFindeksCreditRate { get; set; }



        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarDto>
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

            public async Task<CreateCarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRules.CheckCarByPlate(request.Plate);
                await _carBusinessRules.CheckCarByModelYear(request.ModelYear);

                Car mappedCar = _mapper.Map<Car>(request);
                Car createdCar = await _carRepository.AddAsync(mappedCar);

                CreateCarDto carDtoToReturn = _mapper.Map<CreateCarDto>(createdCar);
                return carDtoToReturn;
            }

        }

    }
}
