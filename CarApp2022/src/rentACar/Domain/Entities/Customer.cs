using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity
{
    public string ContactNumber { get; set; }
    public string ContactEmail { get; set; }

    public virtual CorporateCustomer? CorporateCustomer { get; set; }
    public virtual IndividualCustomer? IndividualCustomer { get; set; }
    public virtual FindeksCreditRate? FindeksCreditRate { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }



    public Customer()
    {
        Invoices = new HashSet<Invoice>();
        Rentals = new HashSet<Rental>();
    }

    public Customer(int id, string contactNumber, string contactEmail) : base(id)
    {
        Id = id;
        ContactEmail = contactEmail;
        ContactNumber = contactNumber;
    }
}