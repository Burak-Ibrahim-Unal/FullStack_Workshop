using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries
{
    public class GetVehicleListQuery : IRequest<VehicleListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetVehicleListQuery, VehicleListModel>
        {
            public readonly IVehicleRepository _vehicleRepository;
            public readonly IMapper _mapper;

            public GetListQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
            {
                _vehicleRepository = vehicleRepository;
                _mapper = mapper;
            }

            public async Task<VehicleListModel> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<VehicleListDto> vehicles = await _vehicleRepository.GetAllVehicles(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                VehicleListModel mappedModels = _mapper.Map<VehicleListModel>(vehicles);

                return mappedModels;

            }
        }
    }
}