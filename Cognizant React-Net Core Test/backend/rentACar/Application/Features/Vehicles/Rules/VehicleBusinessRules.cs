using Application.Features.Vehicles.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Rules
{
    public class VehicleBusinessRules
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleBusinessRules(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }


        public async Task CheckVehicleDtoisNull(VehicleDto vehicleDto)
        {
            if (vehicleDto == null) throw new BusinessException(Messages.VehicleDoesNotExist);
        }

    }


}

