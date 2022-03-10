using Application.Features.Warehouses.Dtos;
using Application.Features.Warehouses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Commands
{
    public class CreateWarehouseCommand : IRequest<CreateWarehouseDto>
    {
        public string Name { get; set; }
        public int LocationId { get; set; }


        public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, CreateWarehouseDto>
        {
            private readonly IWarehouseRepository _warehouseRepository;
            private readonly IMapper _mapper;
            private readonly WarehouseBusinessRules _warehouseBusinessRules;
            private readonly ICacheService _cacheService;

            public CreateWarehouseCommandHandler(
                IWarehouseRepository warehouseRepository,
                IMapper mapper,
                WarehouseBusinessRules warehouseBusinessRules,
                ICacheService cacheService
            )
            {
                _warehouseRepository = warehouseRepository;
                _mapper = mapper;
                _warehouseBusinessRules = warehouseBusinessRules;
                _cacheService = cacheService;

            }


            /// <summary>
            /// If warehouse is created,cache will ve removed...Create method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<CreateWarehouseDto> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
            {
                Warehouse mappedWarehouse = _mapper.Map<Warehouse>(request);
                Warehouse createdWarehouse = await _warehouseRepository.AddAsync(mappedWarehouse);

                _cacheService.Remove("warehouses-list", "warehouses-list-available");

                CreateWarehouseDto warehouseDtoToReturn = _mapper.Map<CreateWarehouseDto>(createdWarehouse);
                return warehouseDtoToReturn;
            }

        }

    }
}
