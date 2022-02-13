using Application.Features.Maintenances.Dtos;
using Application.Features.Maintenances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Maintenances.Queries.GetByIdMaintenance;

public class GetMaintenanceByIdQuery : IRequest<Maintenance>
{
    public int Id { get; set; }

    public class GetMaintenanceByIdQueryHandler : IRequestHandler<GetMaintenanceByIdQuery, Maintenance>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IMapper _mapper;
        private readonly MaintenanceBusinessRules _maintenanceBusinessRules;

        public GetMaintenanceByIdQueryHandler(IMaintenanceRepository maintenanceRepository, MaintenanceBusinessRules maintenanceBusinessRules,
                                        IMapper mapper)
        {
            _maintenanceRepository = maintenanceRepository;
            _maintenanceBusinessRules = maintenanceBusinessRules;
            _mapper = mapper;
        }


        public async Task<Maintenance> Handle(GetMaintenanceByIdQuery request, CancellationToken cancellationToken)
        {
            await _maintenanceBusinessRules.CheckMaintenanceById(request.Id);

            var maintenance = await _maintenanceRepository.GetAsync(b => b.Id == request.Id);
            return maintenance;
        }
    }
}