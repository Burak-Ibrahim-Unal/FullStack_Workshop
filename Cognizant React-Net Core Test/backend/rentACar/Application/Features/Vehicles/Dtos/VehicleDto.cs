using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseLatitude { get; set; }
        public string WarehouseLongitude { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
