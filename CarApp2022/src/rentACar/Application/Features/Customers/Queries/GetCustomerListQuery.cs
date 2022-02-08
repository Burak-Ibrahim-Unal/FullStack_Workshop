using Application.Features.Customers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries;

public class GetCustomerListQuery : IRequest<CustomerListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetCustomerListResponseHandler : IRequestHandler<GetCustomerListQuery, CustomerListModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListResponseHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerListModel> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Customer> customers = await _customerRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            CustomerListModel mappedCustomerListModel = _mapper.Map<CustomerListModel>(customers);
            return mappedCustomerListModel;
        }
    }
}