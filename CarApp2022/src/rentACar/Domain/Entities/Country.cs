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
        public string Name { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }


        public Country()
        {
            Provinces = new HashSet<Province>();
        }

        public Country(int id, string name) : base(id)
        {
            Id = id;
            Name = name;
        }
    }
}
