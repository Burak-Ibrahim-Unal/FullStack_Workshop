﻿using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<Car>
    {
        public string Name { get; set; }


        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
        {
            ICarRepository _carRepository;
            IMapper _mapper;
            CarBusinessRules _carBusinessRules;

            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRules.CarNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedCar = _mapper.Map<Car>(request);

                var createdCar = await _carRepository.AddAsync(mappedCar);
                return createdCar;
            }

        }

    }
}
