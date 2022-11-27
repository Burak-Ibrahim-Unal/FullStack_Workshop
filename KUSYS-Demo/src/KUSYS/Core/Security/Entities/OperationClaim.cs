using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Entities
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }

        public OperationClaim()
        {

        }

        public OperationClaim(int id, string name) : base(id)
        {
            Id = id;
            Name = name;
        }
    }
}
