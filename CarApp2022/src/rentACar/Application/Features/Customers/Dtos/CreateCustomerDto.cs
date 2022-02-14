namespace Application.Features.Customers.Dtos;

public class CreateCustomerDto
{
    public int Id { get; set; }
    public string ContactNumber { get; set; }
    public string ContactEmail { get; set; }
}