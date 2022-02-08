using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Queries;

public class GetCorporateCustomerByIdQuery : IRequest<CorporateCustomer>
{
    public int Id { get; set; }

    public class GetCorporateCustomerByIdResponseHandler : IRequestHandler<GetCorporateCustomerByIdQuery, CorporateCustomer>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public GetCorporateCustomerByIdResponseHandler(ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }


        public async Task<CorporateCustomer> Handle(GetCorporateCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            await _corporateCustomerBusinessRules.CorporateCustomerIdShouldExistWhenSelected(request.Id);

            var corporateCustomer = await _corporateCustomerRepository.GetAsync(b => b.Id == request.Id);
            return corporateCustomer;
        }
    }
}