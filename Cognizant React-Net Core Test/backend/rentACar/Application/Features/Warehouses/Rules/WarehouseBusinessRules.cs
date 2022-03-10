using Application.Features.Warehouses.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Rules
{
    public class WarehouseBusinessRules
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseBusinessRules(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }


        public async Task CheckWarehouseDtoisNull(WarehouseDto warehouseDto)
        {
            if (warehouseDto == null) throw new BusinessException(Messages.WarehouseDoesNotExist);
        }

    }


}

