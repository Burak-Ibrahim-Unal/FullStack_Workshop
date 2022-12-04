using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : Entity
    {
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public Address()
        {

        }

        public Address(int id,string fullName,string addAddress1,string addAddress2,string city,string state,string zip,string country) : base(id)
        {
            Id= id;
            FullName= fullName;
            Address1 = addAddress1;
            Address2 = addAddress2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }
    }
}
