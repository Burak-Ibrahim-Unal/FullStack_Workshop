using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class District : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public District()
        {

        }

        public District(int id, string name) : base(id)
        {
            Id = id;
            Name = name;
        }
    }
}
