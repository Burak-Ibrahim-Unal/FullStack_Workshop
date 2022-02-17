using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RentalOffice : Entity
{
    public int DistrictId { get; set; }

    public virtual District Districts { get; set; }
    public virtual ICollection<Car> Cars { get; set; }


    public RentalOffice()
    {
        Cars = new HashSet<Car>();
    }

    public RentalOffice(int id, int districtId) : base(id)
    {
        Id = id;
        DistrictId = districtId;

    }
}
