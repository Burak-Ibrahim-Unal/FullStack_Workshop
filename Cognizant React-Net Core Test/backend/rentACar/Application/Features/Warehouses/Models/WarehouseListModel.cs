using Application.Features.Warehouses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Models
{
    public class WarehouseListModel : BasePageableModel
    {
        public IList<WarehouseListDto> Items { get; set; }


    }
}
