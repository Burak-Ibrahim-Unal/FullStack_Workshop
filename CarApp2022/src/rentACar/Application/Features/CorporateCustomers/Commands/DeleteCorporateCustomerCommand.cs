using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands;

public class DeleteCorporateCustomerCommand : IRequest<CorporateCustomerDeleteDto>
{
    public int Id { get; set; }

    public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, CorporateCustomerDeleteDto>
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

        public async Task<CorporateCustomerDeleteDto> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _corporateCustomerBusinessRules.CheckCorporateCustomerById(request.Id);

            var mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
            var deletedCorporateCustomer = await _corporateCustomerRepository.DeleteAsync(mappedCorporateCustomer);
            var returnToDeletedCorporateCustomer = _mapper.Map<CorporateCustomerDeleteDto>(deletedCorporateCustomer);

            return returnToDeletedCorporateCustomer;
        }
    }
}