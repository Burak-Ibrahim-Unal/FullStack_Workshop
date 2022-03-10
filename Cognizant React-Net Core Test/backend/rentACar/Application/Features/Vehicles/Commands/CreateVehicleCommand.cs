using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vehicles.Commands
{
    public class CreateVehicleCommand : IRequest<CreateVehicleDto>
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }



        public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleDto>
        {
            private readonly IVehicleRepository _vehicleRepository;
            private readonly IMapper _mapper;
            private readonly VehicleBusinessRules _vehicleBusinessRules;
            private readonly ICacheService _cacheService;

            public CreateVehicleCommandHandler(
                IVehicleRepository vehicleRepository,
                IMapper mapper,
                VehicleBusinessRules vehicleBusinessRules,
                ICacheService cacheService
            )
            {
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
                _vehicleBusinessRules = vehicleBusinessRules;
                _cacheService = cacheService;

            }


            /// <summary>
            /// If vehicle is created,cache will ve removed...Create method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<CreateVehicleDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
            {
                Vehicle mappedVehicle = _mapper.Map<Vehicle>(request);
                mappedVehicle.DateAdded = DateTime.Now;
                Vehicle createdVehicle = await _vehicleRepository.AddAsync(mappedVehicle);

                _cacheService.Remove("vehicles-list", "vehicles-list-available");

                CreateVehicleDto vehicleDtoToReturn = _mapper.Map<CreateVehicleDto>(createdVehicle);
                return vehicleDtoToReturn;
            }

        }

    }
}
