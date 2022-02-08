using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MaintenanceRepository : EfRepositoryBase<Maintenance, BaseDbContext>, IMaintenanceRepository
    {
        public MaintenanceRepository(BaseDbContext baseDbContext) : base(baseDbContext)
        {

        }

        public bool CheckIfCarIsMaintenance(int carId)
        {
            var result = Context.Maintenances.Where(m => m.ReturnDate == null && m.CarId == carId).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}