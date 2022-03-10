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
    public class DeleteWarehouseCommand : IRequest<DeleteWarehouseDto>
    {
        public int Id { get; set; }


        public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, DeleteWarehouseDto>
        {
            private readonly IWarehouseRepository _warehouseRepository;
            private readonly IMapper _mapper;
            private readonly ICacheService _cacheService;


            public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IMapper mapper, ICacheService cacheService)
            {
                _warehouseRepository = warehouseRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            /// <summary>
            /// If warehouse is deleted,cache will ve removed...Delete method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<DeleteWarehouseDto> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
            {

                var deletedWarehouseDto = await _warehouseRepository.GetWarehouseById(request.Id);

                if (deletedWarehouseDto == null) throw new BusinessException(Messages.WarehouseDoesNotExist);

                Warehouse warehouseToDelete = _mapper.Map<Warehouse>(request);
                await _warehouseRepository.DeleteAsync(warehouseToDelete);


                _cacheService.Remove("warehouses-list", "warehouses-list-available", "warehouses-list-not-available", "warehouses-list-rented", "warehouses-list-under-maintenance");


                DeleteWarehouseDto returnToDeletedWarehouseDto = _mapper.Map<DeleteWarehouseDto>(deletedWarehouseDto);
                return returnToDeletedWarehouseDto;

            }

        }

    }
}
