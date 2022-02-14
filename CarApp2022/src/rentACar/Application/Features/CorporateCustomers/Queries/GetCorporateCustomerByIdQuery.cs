using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Queries;

public class GetCorporateCustomerByIdQuery : IRequest<CorporateCustomerDto>
{
    public int Id { get; set; }

    public class GetCorporateCustomerByIdResponseHandler : IRequestHandler<GetCorporateCustomerByIdQuery, CorporateCustomerDto>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly IMapper _mapper;


        public GetCorporateCustomerByIdResponseHandler(ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IMapper mapper)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _mapper = mapper;
        }


        public async Task<CorporateCustomerDto> Handle(GetCorporateCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            await _corporateCustomerBusinessRules.CheckCorporateCustomerById(request.Id);

            CorporateCustomer corporateCustomer = await _corporateCustomerRepository.GetAsync(b => b.Id == request.Id);
            CorporateCustomerDto corporateCustomerDto = _mapper.Map<CorporateCustomerDto>(corporateCustomer);

            return corporateCustomerDto;
        }
    }
}