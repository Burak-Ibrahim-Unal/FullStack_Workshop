using Application.Features.Maintenances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
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
            public readonly IMaintenanceRepository _maintenanceRepository;
            public readonly IMapper _mapper;
            public readonly MaintenanceBusinessRules _maintenanceBusinessRules;

            public CreateMaintenanceCommandHandler(
                IMaintenanceRepository maintenanceRepository, 
                IMapper mapper, 
                MaintenanceBusinessRules maintenanceBusinessRules
            )
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
                _maintenanceBusinessRules = maintenanceBusinessRules;
            }

            public async Task<Maintenance> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                await _maintenanceBusinessRules.CheckCarMaintenanceStatus(request.CarId);
                await _maintenanceBusinessRules.CheckMaintenanceStatusByMaintenanceDate(request.MaintenanceDate);
                await _maintenanceBusinessRules.CheckMaintenanceStatusByReturnDate(request.ReturnDate);

                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var createdMaintenance = await _maintenanceRepository.AddAsync(mappedMaintenance);

                return createdMaintenance;
            }
        }

    }
}