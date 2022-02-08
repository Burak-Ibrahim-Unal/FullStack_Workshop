using Application.Features.Invoices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Invoices.Queries;

public class GetInvoiceListQuery : IRequest<InvoiceListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, InvoiceListModel>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceListQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceListModel> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Invoice> invoices = await _invoiceRepository.GetListAsync(index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
            InvoiceListModel mappedInvoiceListModel = _mapper.Map<InvoiceListModel>(invoices);
            return mappedInvoiceListModel;
        }
    }
}