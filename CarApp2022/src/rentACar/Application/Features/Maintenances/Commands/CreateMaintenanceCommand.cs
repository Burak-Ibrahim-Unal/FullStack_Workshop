using Application.Features.Maintenances.Dtos;
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
    public class CreateMaintenanceCommand : IRequest<CreateMaintenanceDto>
    {
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CarId { get; set; }


        public class CreateMaintenanceCommandHandler : IRequestHandler<CreateMaintenanceCommand, CreateMaintenanceDto>
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

            public async Task<CreateMaintenanceDto> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
            {
                await _maintenanceBusinessRules.CheckCarMaintenanceStatus(request.CarId);

                Maintenance mappedMaintenance = _mapper.Map<Maintenance>(request);
                Maintenance createdMaintenance = await _maintenanceRepository.AddAsync(mappedMaintenance);

                CreateMaintenanceDto maintenanceDtoToReturn = _mapper.Map<CreateMaintenanceDto>(createdMaintenance);

                return maintenanceDtoToReturn;
            }
        }

    }
}