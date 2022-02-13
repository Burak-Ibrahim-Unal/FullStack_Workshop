﻿namespace Application.Features.CorporateCustomers.Dtos;

public class CreateCorporateCustomerDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string? CompanyShortName { get; set; }

    public string TaxNo { get; set; }
}