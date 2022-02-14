using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands
{
    public class UpdateFuelCommand : IRequest<UpdateFuelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdateFuelDto>
        {
            private IFuelRepository _fuelRepository;
            private IMapper _mapper;
            private FuelBusinessRules _fuelBusinessRules;

            public UpdateFuelCommandHandler(FuelBusinessRules fuelBusinessRules, IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelBusinessRules = fuelBusinessRules;
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<UpdateFuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {

                Fuel mappedFuel = _mapper.Map<Fuel>(request);
                Fuel updatedFuel = await _fuelRepository.UpdateAsync(mappedFuel);

                UpdateFuelDto updatedFuelDtoToReturn = _mapper.Map<UpdateFuelDto>(updatedFuel);
                return updatedFuelDtoToReturn;
            }

        }

    }
}
