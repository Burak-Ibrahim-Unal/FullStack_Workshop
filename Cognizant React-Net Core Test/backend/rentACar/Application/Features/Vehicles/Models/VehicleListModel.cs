using Application.Features.Vehicles.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Models
{
    public class VehicleListModel : BasePageableModel
    {
        public IList<VehicleListDto> Items { get; set; }


    }
}
