using Application.Features.Warehouses.Dtos;
using Application.Features.Warehouses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Warehouses.Queries;

public class GetWarehouseByIdQuery : IRequest<WarehouseDto>
{
    public int Id { get; set; }

    public class GetWarehouseByIdResponseHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseDto>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly WarehouseBusinessRules _warehouseBusinessRules;

        public GetWarehouseByIdResponseHandler(IWarehouseRepository warehouseRepository, WarehouseBusinessRules warehouseBusinessRules)
        {
            _warehouseRepository = warehouseRepository;
            _warehouseBusinessRules = warehouseBusinessRules;
        }


        public async Task<WarehouseDto> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {

            WarehouseDto warehouse = await _warehouseRepository.GetWarehouseById(request.Id);

            await _warehouseBusinessRules.CheckWarehouseDtoisNull(warehouse);

            return warehouse;
        }

    }
}