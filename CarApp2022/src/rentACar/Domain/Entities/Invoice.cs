using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Invoice : Entity
{
    public int CustomerId { get; set; }
    public string SerialNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime RentalStartDate { get; set; }
    public DateTime? RentalEndDate { get; set; }
    public short TotalRentalDay { get; set; }
    public decimal RentalPrice { get; set; }

    public virtual Customer Customer { get; set; }

    public Invoice()
    {
    }

    public Invoice(int id, int customerId, string serialNumber, DateTime createdDate, DateTime rentalStartDate,DateTime rentalEndDate, short totalRentalDay, decimal rentalPrice) : base(id)
    {
        Id = id;
        CustomerId = customerId;
        SerialNumber = serialNumber;
        CreatedDate = createdDate;
        RentalStartDate = rentalStartDate;
        RentalEndDate = rentalEndDate;
        TotalRentalDay = totalRentalDay;
        RentalPrice = rentalPrice;
    }
}