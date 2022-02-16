using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : Entity
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }


        public virtual District District { get; set; }
        public virtual Province Province { get; set; }


        public Country()
        {

        }

        public Country(int id, int provinceId, int districtId, string name) : base(id)
        {
            Id = id;
            ProvinceId = provinceId;
            DistrictId = districtId;
            Name = name;
        }
    }
}
