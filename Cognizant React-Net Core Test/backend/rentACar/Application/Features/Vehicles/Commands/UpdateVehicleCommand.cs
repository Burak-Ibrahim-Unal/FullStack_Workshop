using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Rules;
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

namespace Application.Features.Vehicles.Commands
{
    public class UpdateVehicleCommand : IRequest<UpdateVehicleDto>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }



        public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, UpdateVehicleDto>
        {
            private IVehicleRepository _vehicleRepository;
            private IMapper _mapper;
            private VehicleBusinessRules _vehicleBusinessRules;
            private readonly ICacheService _cacheService;


            public UpdateVehicleCommandHandler(
                VehicleBusinessRules vehicleBusinessRules,
                IVehicleRepository vehicleRepository,
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _vehicleBusinessRules = vehicleBusinessRules;
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
                _cacheService= cacheService;
            }

            /// <summary>
            /// If vehicle is update,cache will ve removed...Update method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<UpdateVehicleDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
            {
                var updateVehicleDto = await _vehicleRepository.GetVehicleById(request.Id);

                if (updateVehicleDto == null) throw new BusinessException(Messages.VehicleDoesNotExist);

                Vehicle vehicleToUpdate = _mapper.Map<Vehicle>(request);

                await _vehicleRepository.UpdateAsync(vehicleToUpdate);

                _cacheService.Remove("vehicles-list", "vehicles-list-available", "vehicles-list-not-available", "vehicles-list-rented", "vehicles-list-under-maintenance");

                UpdateVehicleDto updatedVehicleDto = _mapper.Map<UpdateVehicleDto>(vehicleToUpdate);
                return updatedVehicleDto;
            }

        }

    }
}
