using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Queries;

public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomer>
{
    public int Id { get; set; }

    public class GetIndividualCustomerByIdResponseHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomer>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public GetIndividualCustomerByIdResponseHandler(IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }


        public async Task<IndividualCustomer> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            await _individualCustomerBusinessRules.CheckIndividualCustomerById(request.Id);

            var individualCustomer = await _individualCustomerRepository.GetAsync(b => b.Id == request.Id);
            return individualCustomer;
        }
    }
}