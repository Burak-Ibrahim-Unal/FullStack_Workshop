using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Province : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<District> Districts { get; set; }


        public Province()
        {
            Districts = new HashSet<District>();
        }

        public Province(int id, string name, ICollection<District> districts):base(id)
        {
            Id = id;
            Name = name;
            Districts = districts;
        }
    }
}
