using Application.Features.Maintenances.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Models
{
    public class MaintenanceListModel : BasePageableModel
    {
        public IList<MaintenanceListDto> Items { get; set; }
    }
}