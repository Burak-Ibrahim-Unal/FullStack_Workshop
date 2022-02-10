using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Entities
{
    public class OperationClaim : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
