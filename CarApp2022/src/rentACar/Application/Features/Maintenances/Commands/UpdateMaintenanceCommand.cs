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
    public class UpdateMaintenanceCommand : IRequest<Maintenance>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CarId { get; set; }

        public class UpdateMaintenanceCommandHandler : IRequestHandler<UpdateMaintenanceCommand, Maintenance>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;
            MaintenanceBusinessRules _maintenanceBusinessRules;

            public UpdateMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper, MaintenanceBusinessRules maintenanceBusinessRules)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
                _maintenanceBusinessRules = maintenanceBusinessRules;
            }

            public async Task<Maintenance> Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                var mappedMaintenance = _mapper.Map<Maintenance>(request);
                var updatedMaintenance = await _maintenanceRepository.UpdateAsync(mappedMaintenance);
                return updatedMaintenance;
            }
        }
    }
}