using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CarDamage : Entity
{
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsReady { get; set; } = false;

    public virtual Car Car { get; set; }


    public CarDamage()
    {
    }

    public CarDamage(int id, int carId, string description, bool isReady) : base(id)
    {
        Id = id;    
        CarId = carId;
        Description = description;
        IsReady = isReady;
    }
}