using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands
{
    public class CreateFuelCommand : IRequest<FuelCreateDto>
    {
        public string Name { get; set; }


        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, FuelCreateDto>
        {
            IFuelRepository _fuelRepository;
            IMapper _mapper;
            FuelBusinessRules _fuelBusinessRules;


            public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
                _fuelBusinessRules = fuelBusinessRules;
            }


            public async Task<FuelCreateDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {

                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedFuel = _mapper.Map<Fuel>(request);
                var createdFuel = await _fuelRepository.AddAsync(mappedFuel);

                var colorToReturn= _mapper.Map<FuelCreateDto>(request);
                return colorToReturn;
            }

        }

    }
}
