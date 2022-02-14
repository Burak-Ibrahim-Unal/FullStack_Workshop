using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public int Id { get; set; }

    public class GetCustomerByIdQueryResponseHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IMapper _mapper;


        public GetCustomerByIdQueryResponseHandler(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
            _mapper = mapper;
        }


        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CheckCustomerById(request.Id);

            Customer? customer = await _customerRepository.GetAsync(b => b.Id == request.Id);
            CustomerDto customerDtoToReturn = _mapper.Map<CustomerDto>(customer);
            return customerDtoToReturn;
        }
    }
}