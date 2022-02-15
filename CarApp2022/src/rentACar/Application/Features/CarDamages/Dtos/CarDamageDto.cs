namespace Application.Features.CarDamages.Dtos;

public class CarDamageDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsFixed { get; set; }
}