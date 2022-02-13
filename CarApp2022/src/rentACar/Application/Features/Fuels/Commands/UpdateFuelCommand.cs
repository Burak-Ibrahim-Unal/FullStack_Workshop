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

                var fuelToUpdate = await _fuelRepository.GetAsync(fuel => fuel.Id == request.Id);

                if (fuelToUpdate == null) throw new BusinessException(Messages.FuelDoesNotExist);

                await _fuelBusinessRules.CheckFuelByName(request.Name);

                _mapper.Map(request, fuelToUpdate);
                await _fuelRepository.UpdateAsync(fuelToUpdate);
                var updatedFuel = _mapper.Map<UpdateFuelDto>(fuelToUpdate);

                return updatedFuel;
            }

        }

    }
}
