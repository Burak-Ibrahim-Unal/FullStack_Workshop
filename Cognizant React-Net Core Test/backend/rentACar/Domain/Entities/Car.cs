using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : Entity
    {
        //id,location,vehiclesId
        public int WarehouseId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual Warehouse? Warehouse { get; set; }


        public Car()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public Car(int id,int warehouseId, string location) : this()
        {
            Id = id;
            WarehouseId = warehouseId;
            Location = location;
        }
    }
}
