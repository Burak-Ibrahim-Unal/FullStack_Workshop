using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands;

public class UpdateCorporateCustomerCommand : IRequest<UpdateCorporateCustomerDto>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string TaxNo { get; set; }

    public class
        UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdateCorporateCustomerDto>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository,
                                                     IMapper mapper,
                                                     CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<UpdateCorporateCustomerDto> Handle(UpdateCorporateCustomerCommand request,
                                                    CancellationToken cancellationToken)
        {
            await _corporateCustomerBusinessRules.CheckCorporateCustomerByTaxNo(request.TaxNo);

            CorporateCustomer corporateCustomerToUpdate = await _corporateCustomerRepository.GetAsync(x => x.Id == request.Id);

            if (corporateCustomerToUpdate == null) throw new BusinessException(Messages.CustomerDoesNotExist);

            CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
            CorporateCustomer updatedCorporateCustomer = await _corporateCustomerRepository.UpdateAsync(mappedCorporateCustomer);
            
            UpdateCorporateCustomerDto returnToUpdatedCorporateCustomer = _mapper.Map<UpdateCorporateCustomerDto>(updatedCorporateCustomer);
            return returnToUpdatedCorporateCustomer;
        }
    }
}