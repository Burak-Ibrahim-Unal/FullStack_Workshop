using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task CheckCorporateCustomerById(int id)
    {
        CorporateCustomer? result = await _corporateCustomerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(Messages.CustomerDoesNotExist);
    }

    public async Task CheckCorporateCustomerByTaxNo(string taxNo)
    {
        IPaginate<CorporateCustomer> result = await _corporateCustomerRepository.GetListAsync(c => c.TaxNo == taxNo);
        if (result.Items.Any()) throw new BusinessException(Messages.CustomerTaxNoDoesNotExist);
    }
}