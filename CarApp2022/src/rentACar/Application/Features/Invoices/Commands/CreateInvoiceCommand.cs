using Application.Features.Invoices.Dtos;
using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Invoices.Commands;

public class CreateInvoiceCommand : IRequest<CreateInvoiceDto>
{
    public int CustomerId { get; set; }
    public string SerialNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime RentalStartDate { get; set; }
    public DateTime? RentalEndDate { get; set; }
    public short TotalRentalDay { get; set; }
    public decimal RentalPrice { get; set; }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper,
                                           InvoiceBusinessRules invoiceBusinessRules)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CreateInvoiceDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            Invoice mappedInvoice = _mapper.Map<Invoice>(request);

            Invoice createdInvoice = await _invoiceRepository.AddAsync(mappedInvoice);

            var invoiceToReturn = _mapper.Map<CreateInvoiceDto>(createdInvoice);

            return invoiceToReturn;
        }
    }
}