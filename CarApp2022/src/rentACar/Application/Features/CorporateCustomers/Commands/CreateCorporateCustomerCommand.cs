using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands;

public class CreateCorporateCustomerCommand : IRequest<CorporateCustomerCreateDto>
{
    public int CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string? CompanyShortName { get; set; }
    public string TaxNo { get; set; }


    public class
        CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CorporateCustomerCreateDto>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository,
                                                     IMapper mapper,
                                                     CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<CorporateCustomerCreateDto> Handle(CreateCorporateCustomerCommand request,
                                                    CancellationToken cancellationToken)
        {
            await _corporateCustomerBusinessRules.CheckCorporateCustomerTaxNo(request.TaxNo);

            var mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
            var createdCorporateCustomer =
                await _corporateCustomerRepository.AddAsync(mappedCorporateCustomer);
            var corporateCustomerDtoToReturn = _mapper.Map<CorporateCustomerCreateDto>(createdCorporateCustomer);
            return corporateCustomerDtoToReturn;
        }
    }
}