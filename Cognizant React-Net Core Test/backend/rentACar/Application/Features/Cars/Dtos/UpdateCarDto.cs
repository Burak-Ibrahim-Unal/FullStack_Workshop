using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Dtos
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string Location { get; set; }


    }
}
