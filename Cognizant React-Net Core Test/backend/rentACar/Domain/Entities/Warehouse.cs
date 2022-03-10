using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Warehouse : Entity
    {
        public string Name { get; set; }
        public int LocationId { get; set; }


        public virtual Location? Location { get; set; }


        public Warehouse()
        {

        }

        public Warehouse(int id, int locationId, string name) : this()
        {
            Id = id;
            Name = name;
            LocationId = locationId;
        }
    }
}
