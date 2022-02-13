using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Commands;

public class UpdateIndividualCustomerCommand : IRequest<IndividualCustomerUpdateDto>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }

    public class
        UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, IndividualCustomerUpdateDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository,
                                                      IMapper mapper,
                                                      IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<IndividualCustomerUpdateDto> Handle(UpdateIndividualCustomerCommand request,
                                                     CancellationToken cancellationToken)
        {
            await _individualCustomerBusinessRules.CheckIndividualCustomerByINationalIdentity(
                request.NationalIdentity);

            var mappedIndividualCustomer = _mapper.Map<IndividualCustomer>(request);
            var updatedIndividualCustomer =await _individualCustomerRepository.UpdateAsync(mappedIndividualCustomer);
            var returnToUpdatedIndividualCustomer = _mapper.Map<IndividualCustomerUpdateDto>(updatedIndividualCustomer);

            return returnToUpdatedIndividualCustomer;
        }
    }
}