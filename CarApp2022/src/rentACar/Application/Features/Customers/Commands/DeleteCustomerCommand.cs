using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands;

public class DeleteCustomerCommand : IRequest<DeleteCustomerDto>
{
    public int Id { get; set; }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
                                         CustomerBusinessRules customerBusinessRules)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<DeleteCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CheckCustomerById(request.Id);

            var customerToUpdate = await _customerRepository.GetAsync(x => x.Id == request.Id);

            if (customerToUpdate == null) throw new BusinessException(Messages.CustomerDoesNotExist);

            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer deletedCustomer = await _customerRepository.DeleteAsync(mappedCustomer);

            DeleteCustomerDto returnToDeletedCustomer = _mapper.Map<DeleteCustomerDto>(deletedCustomer);
            return returnToDeletedCustomer;
        }
    }
}