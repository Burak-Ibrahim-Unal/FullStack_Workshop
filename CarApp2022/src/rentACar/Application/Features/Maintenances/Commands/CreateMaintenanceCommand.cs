using Application.Features.Cars.Rules;
using Application.Features.Maintenances.Rules;
using Application.Features.Rentals.Rules;
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

namespace Application.Features.Maintenances.Commands
{
    public class CreateMaintenanceCommand : IRequest<Maintenance>
    {
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CarId { get; set; }


        public class CreateMaintenanceCommandHandler : IRequestHandler<CreateMaintenanceCommand, Maintenance>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;
            MaintenanceBusinessRules _maintenanceBusinessRules;
            RentalBusinessRules _rentalBusinessRules;
            CarBusinessRules _carBusinessRules;

            public CreateMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper, MaintenanceBusinessRules maintenanceBusinessRules, RentalBusinessRules rentalBusinessRules, CarBusinessRules carBusinessRules)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
                _maintenanceBusinessRules = maintenanceBusinessRules;
                _rentalBusinessRules = rentalBusinessRules;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<Maintenance> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                _maintenanceBusinessRules.CheckIfCarIsMaintenance(request.CarId);
                //_rentalBusinessRules.CheckIfCarIsRented(request.CarId);

                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var createdMaintenance = await _maintenanceRepository.AddAsync(mappedMaintenance);

                Console.WriteLine(CarState.Maintenance.ToString());
                await _carBusinessRules.CheckCarState(request.CarId, CarState.Maintenance);

                return createdMaintenance;
            }
        }

    }
}