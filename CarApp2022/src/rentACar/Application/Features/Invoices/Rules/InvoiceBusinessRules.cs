using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.Invoices.Rules;

public class InvoiceBusinessRules
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceBusinessRules(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task CheckInvoiceById(int id)
    {
        Invoice? result = await _invoiceRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(Messages.InvoiceDoesNotExist);
    }

    public async Task CheckInvoiceBySerialNumberNotExist(string serialNumber)
    {
        Invoice result = await _invoiceRepository.GetAsync(invoice => invoice.SerialNumber == serialNumber);

        if (result == null) throw new BusinessException(Messages.InvoiceDoesNotExist);
    }

    public async Task CheckInvoiceBySerialNumberExist(string serialNumber)
    {
        Invoice result = await _invoiceRepository.GetAsync(invoice => invoice.SerialNumber == serialNumber);

        if (result != null) throw new BusinessException(Messages.InvoiceExists);
    }


}
