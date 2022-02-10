using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Rules
{
    public class MaintenanceBusinessRules
    {
        IMaintenanceRepository _maintenanceRepository;

        public MaintenanceBusinessRules(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public bool CheckIfCarIsMaintenance(int carId)
        {
            var result = _maintenanceRepository.CheckIfCarIsMaintenance(carId);
            if (result) throw new BusinessException(Messages.CarCanNotBeRentedWhenUnderMaintenance);

            return result;
        }


        public async Task MaintenanceCanNotBeEmptyWhenSelected(int id)
        {
            var result = await _maintenanceRepository.GetAsync(maintenance => maintenance.Id == id);

            if (result == null) throw new BusinessException(Messages.MaintenanceDoesNotExist);
        }
    }
}