using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location : Entity
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Location()
        {

        }

        public Location(int id, string latitude, string longitude) : this()
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
