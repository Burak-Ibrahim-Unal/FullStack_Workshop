using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands;

public class DeleteCorporateCustomerCommand : IRequest<DeleteCorporateCustomerDto>
{
    public int Id { get; set; }

    public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeleteCorporateCustomerDto>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper,
                                         CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<DeleteCorporateCustomerDto> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            CorporateCustomer corporateCustomerToDelete = await _corporateCustomerRepository.GetAsync(x => x.Id == request.Id);

            if (corporateCustomerToDelete == null) throw new BusinessException(Messages.CustomerDoesNotExist);

            CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
            CorporateCustomer deletedCorporateCustomer = await _corporateCustomerRepository.DeleteAsync(mappedCorporateCustomer);

            DeleteCorporateCustomerDto returnToDeletedCorporateCustomer = _mapper.Map<DeleteCorporateCustomerDto>(deletedCorporateCustomer);
            return returnToDeletedCorporateCustomer;
        }
    }
}