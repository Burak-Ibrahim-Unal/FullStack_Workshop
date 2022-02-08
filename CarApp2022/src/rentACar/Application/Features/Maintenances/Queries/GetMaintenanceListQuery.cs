using Application.Features.Maintenances.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Queries.GetMaintenanceList
{
    public class GetMaintenanceListQuery : IRequest<MaintenanceListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetMaintenanceListQueryHandler : IRequestHandler<GetMaintenanceListQuery, MaintenanceListModel>
        {
            IMaintenanceRepository _maintenanceRepository;
            IMapper _mapper;

            public GetMaintenanceListQueryHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper)
            {
                _maintenanceRepository = maintenanceRepository;
                _mapper = mapper;
            }

            public async Task<MaintenanceListModel> Handle(GetMaintenanceListQuery request, CancellationToken cancellationToken)
            {
                var maintenances = await _maintenanceRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedMaintenance = _mapper.Map<MaintenanceListModel>(maintenances);
                return mappedMaintenance;
            }
        }
    }
}