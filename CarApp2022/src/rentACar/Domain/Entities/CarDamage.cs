using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CarDamage : Entity
{
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsFixed { get; set; } = false;

    public virtual Car Car { get; set; }


    public CarDamage()
    {
    }

    public CarDamage(int id, int carId, string description, bool isFixed) : base(id)
    {
        Id = id;    
        CarId = carId;
        Description = description;
        IsFixed = isFixed;
    }
}