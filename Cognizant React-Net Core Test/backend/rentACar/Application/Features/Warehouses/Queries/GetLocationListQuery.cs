using Application.Features.Warehouses.Dtos;
using Application.Features.Warehouses.Models;
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

namespace Application.Features.Warehouses.Queries
{
    public class GetWarehouseListQuery : IRequest<WarehouseListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetWarehouseListQuery, WarehouseListModel>
        {
            public readonly IWarehouseRepository _warehouseRepository;
            public readonly IMapper _mapper;

            public GetListQueryHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
            {
                _warehouseRepository = warehouseRepository;
                _mapper = mapper;
            }

            public async Task<WarehouseListModel> Handle(GetWarehouseListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<WarehouseListDto> warehouses = await _warehouseRepository.GetAllWarehouses(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                WarehouseListModel mappedModels = _mapper.Map<WarehouseListModel>(warehouses);

                return mappedModels;

            }
        }
    }
}