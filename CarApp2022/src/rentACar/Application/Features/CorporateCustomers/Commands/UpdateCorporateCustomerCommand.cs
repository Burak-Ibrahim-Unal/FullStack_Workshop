using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
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

            var mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
            var updatedCorporateCustomer = await _corporateCustomerRepository.UpdateAsync(mappedCorporateCustomer);
            var returnToUpdatedCorporateCustomer = _mapper.Map<UpdateCorporateCustomerDto>(updatedCorporateCustomer);

            return returnToUpdatedCorporateCustomer;
        }
    }
}