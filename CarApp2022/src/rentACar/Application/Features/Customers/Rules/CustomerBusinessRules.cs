using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.Customers.Rules;

public class CustomerBusinessRules
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerBusinessRules(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task CheckCustomerById(int id)
    {
        Customer? result = await _customerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(Messages.CustomerDoesNotExist);
    }

    public async Task CheckCustomerByEmail(string email)
    {
        IPaginate<Customer> result = await _customerRepository.GetListAsync(c => c.ContactEmail == email);
        if (result.Items.Any()) throw new BusinessException(Messages.CustomerEmailExists);
    }   
    
    public async Task CheckCustomerByNumber(string contactNumber)
    {
        IPaginate<Customer> result = await _customerRepository.GetListAsync(c => c.ContactNumber == contactNumber);
        if (result.Items.Any()) throw new BusinessException(Messages.CustomerContactNumberExists);
    }
}