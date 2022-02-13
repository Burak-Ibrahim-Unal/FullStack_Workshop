﻿using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;

public class UpdateCustomerCommand : IRequest<UpdateCustomerDto>
{
    public int Id { get; set; }
    public string Email { get; set; }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
                                            CustomerBusinessRules customerBusinessRules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<UpdateCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CheckCustomerByEmail(request.Email);

            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer updatedCustomer = await _customerRepository.UpdateAsync(mappedCustomer);
            var returnToCustomer = _mapper.Map<UpdateCustomerDto>(updatedCustomer);

            return returnToCustomer;
        }
    }
}