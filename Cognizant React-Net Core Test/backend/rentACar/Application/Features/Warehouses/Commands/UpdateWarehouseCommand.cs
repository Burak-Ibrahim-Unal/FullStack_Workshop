using Application.Features.Warehouses.Dtos;
using Application.Features.Warehouses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Commands
{
    public class UpdateWarehouseCommand : IRequest<UpdateWarehouseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }



        public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, UpdateWarehouseDto>
        {
            private IWarehouseRepository _warehouseRepository;
            private IMapper _mapper;
            private WarehouseBusinessRules _warehouseBusinessRules;
            private readonly ICacheService _cacheService;


            public UpdateWarehouseCommandHandler(
                WarehouseBusinessRules warehouseBusinessRules,
                IWarehouseRepository warehouseRepository,
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _warehouseBusinessRules = warehouseBusinessRules;
                _warehouseRepository = warehouseRepository;
                _mapper = mapper;
                _cacheService= cacheService;
            }

            /// <summary>
            /// If warehouse is update,cache will ve removed...Update method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<UpdateWarehouseDto> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
            {
                var updateWarehouseDto = await _warehouseRepository.GetWarehouseById(request.Id);

                if (updateWarehouseDto == null) throw new BusinessException(Messages.WarehouseDoesNotExist);

                Warehouse warehouseToUpdate = _mapper.Map<Warehouse>(request);

                await _warehouseRepository.UpdateAsync(warehouseToUpdate);

                _cacheService.Remove("warehouses-list", "warehouses-list-available", "warehouses-list-not-available", "warehouses-list-rented", "warehouses-list-under-maintenance");

                UpdateWarehouseDto updatedWarehouseDto = _mapper.Map<UpdateWarehouseDto>(warehouseToUpdate);
                return updatedWarehouseDto;
            }

        }

    }
}
