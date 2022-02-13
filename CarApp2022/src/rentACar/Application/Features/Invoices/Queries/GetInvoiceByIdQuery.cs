using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Invoices.Queries;

public class GetInvoiceByIdQuery : IRequest<Invoice>
{
    public int Id { get; set; }

    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository,
                                          InvoiceBusinessRules invoiceBusinessRules)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }


        public async Task<Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            await _invoiceBusinessRules.CheckInvoiceById(request.Id);

            Invoice? invoice = await _invoiceRepository.GetAsync(b => b.Id == request.Id);
            return invoice;
        }
    }
}