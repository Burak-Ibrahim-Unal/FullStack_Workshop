using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;

public class CreateCustomerCommand : IRequest<CreateCustomerDto>
{
    public string ContactNumber { get; set; }
    public string ContactEmail { get; set; }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
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

        public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CheckCustomerByEmail(request.ContactEmail); 
            await _customerBusinessRules.CheckCustomerByNumber(request.ContactNumber);

            Customer mappedCustomer = _mapper.Map<Customer>(request);

            Customer createdCustomer = await _customerRepository.AddAsync(mappedCustomer);

            var customerDtoToReturn = _mapper.Map<CreateCustomerDto>(createdCustomer);

            return customerDtoToReturn;
        }
    }
}