using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Dtos
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
