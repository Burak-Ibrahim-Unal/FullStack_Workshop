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
    public class DeleteVehicleCommand : IRequest<DeleteVehicleDto>
    {
        public int Id { get; set; }


        public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, DeleteVehicleDto>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IMapper _mapper;
            private readonly ICacheService _cacheService;


            public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper, ICacheService cacheService)
            {
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            /// <summary>
            /// If vehicle is deleted,cache will ve removed...Delete method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<DeleteVehicleDto> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
            {

                var deletedVehicleDto = await _vehicleRepository.GetVehicleById(request.Id);

                if (deletedVehicleDto == null) throw new BusinessException(Messages.VehicleDoesNotExist);

                Vehicle vehicleToDelete = _mapper.Map<Vehicle>(request);
                await _vehicleRepository.DeleteAsync(vehicleToDelete);


                _cacheService.Remove("vehicles-list", "vehicles-list-available", "vehicles-list-not-available", "vehicles-list-rented", "vehicles-list-under-maintenance");


                DeleteVehicleDto returnToDeletedVehicleDto = _mapper.Map<DeleteVehicleDto>(deletedVehicleDto);
                return returnToDeletedVehicleDto;

            }

        }

    }
}
