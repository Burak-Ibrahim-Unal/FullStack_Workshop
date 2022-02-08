using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;

public class CreateCustomerCommand : IRequest<CustomerCreateDto>
{
    public string Email { get; set; }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerCreateDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
                                            CustomerBusinessRules customerBusinessRules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<CustomerCreateDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CustomerEmailCanNotBeDuplicatedWhenInserted(request.Email);

            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer createdCustomer = await _customerRepository.AddAsync(mappedCustomer);
            var customerDtoToReturn = _mapper.Map<CustomerCreateDto>(createdCustomer);

            return customerDtoToReturn;
        }
    }
}