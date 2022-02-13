using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }


    public async Task CheckIndividualCustomerById(int id)
    {
        IndividualCustomer? result = await _individualCustomerRepository.GetAsync(b => b.Id == id);

        if (result == null) throw new BusinessException(Messages.CustomerDoesNotExist);
    }


    public async Task CheckIndividualCustomerByINationalIdentity(string nationalIdentity)
    {
        IPaginate<IndividualCustomer> result =
            await _individualCustomerRepository.GetListAsync(c => c.NationalIdentity == nationalIdentity);

        if (result.Items.Any()) throw new BusinessException(Messages.CustomerIdentityNoExists);
    }
}