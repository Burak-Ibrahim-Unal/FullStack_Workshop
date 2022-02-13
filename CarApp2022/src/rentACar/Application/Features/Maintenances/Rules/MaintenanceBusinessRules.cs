using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
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

        public async Task<bool> CheckCarMaintenanceStatus(int carId)
        {
            var result = _maintenanceRepository.CheckCarMaintenanceStatus(carId);

            if (result) throw new BusinessException(Messages.CarCanNotBeRentedWhenUnderMaintenance);

            return result;
        }

        public async Task CheckMaintenanceStatusByMaintenanceDate(DateTime maintenanceDate, DateTime? returnDate = null)
        {

            if (maintenanceDate > DateTime.Now)
                throw new BusinessException(Messages.CompareMaintenanceDateWithToday);


            if (returnDate != null)
                if (maintenanceDate > returnDate)
                    throw new BusinessException(Messages.CompareMaintenanceDateWithReturnDate);


        }

        public async Task CheckMaintenanceStatusByReturnDate(DateTime returnDate)
        {

            if (returnDate > DateTime.Now)
                throw new BusinessException(Messages.CompareReturnDateWithToday);

        }


        public async Task CheckMaintenanceById(int id)
        {
            var result = await _maintenanceRepository.GetAsync(maintenance => maintenance.Id == id);

            if (result == null) throw new BusinessException(Messages.MaintenanceDoesNotExist);
        }
    }
}