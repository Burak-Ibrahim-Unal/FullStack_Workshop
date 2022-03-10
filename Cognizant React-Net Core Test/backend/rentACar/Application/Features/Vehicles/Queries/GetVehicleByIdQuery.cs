using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vehicles.Queries;

public class GetVehicleByIdQuery : IRequest<VehicleDto>
{
    public int Id { get; set; }

    public class GetVehicleByIdResponseHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly VehicleBusinessRules _vehicleBusinessRules;

        public GetVehicleByIdResponseHandler(IVehicleRepository vehicleRepository, VehicleBusinessRules vehicleBusinessRules)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleBusinessRules = vehicleBusinessRules;
        }


        public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {

            VehicleDto vehicle = await _vehicleRepository.GetVehicleById(request.Id);

            await _vehicleBusinessRules.CheckVehicleDtoisNull(vehicle);

            return vehicle;
        }

    }
}