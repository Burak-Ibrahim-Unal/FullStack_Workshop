using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Commands;

public class DeleteIndividualCustomerCommand : IRequest<IndividualCustomerDeleteDto>
{
    public int Id { get; set; }

    public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, IndividualCustomerDeleteDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper,
                                         IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<IndividualCustomerDeleteDto> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _individualCustomerBusinessRules.CheckIndividualCustomerById(request.Id);

            var mappedIndividualCustomer = _mapper.Map<IndividualCustomer>(request);
            var deletedIndividualCustomer = await _individualCustomerRepository.DeleteAsync(mappedIndividualCustomer);
            var returnToDeletedindividualCustomer = _mapper.Map<IndividualCustomerDeleteDto>(deletedIndividualCustomer);

            return returnToDeletedindividualCustomer;
        }
    }
}