using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Rental : Entity
{
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public int RentalStartOfficeId { get; set; }
    public int RentalEndOfficeId { get; set; }

    public DateTime RentalStartDate { get; set; }
    public DateTime? RentalEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentalStartKilometer { get; set; }
    public int? RentalEndKilometer { get; set; }


    public virtual Car Car { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual RentalOffice RentalStartOffice { get; set; }
    public virtual RentalOffice RentalEndOffice { get; set; }

    public Rental()
    {
    }

    public Rental(int id, int customerId, int carId, int rentalStartOfficeId, int rentalEndOfficeId,
                  DateTime rentalStartDate, DateTime rentalEndDate, DateTime? returnDate, int rentalStartKilometer,
                  int rentalEndKilometer)
    {
        Id = id;
        CustomerId = customerId;
        CarId = carId;
        RentalStartOfficeId = rentalStartOfficeId;
        RentalEndOfficeId = rentalEndOfficeId;
        RentalStartDate = rentalStartDate;
        RentalEndDate = rentalEndDate;
        ReturnDate = returnDate;
        RentalStartKilometer = rentalStartKilometer;
        RentalEndKilometer = rentalEndKilometer;
    }
}