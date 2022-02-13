using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.FindeksCreditRates.Rules;

public class FindeksCreditRateBusinessRules
{
    private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;

    public FindeksCreditRateBusinessRules(IFindeksCreditRateRepository findeksCreditRateRepository)
    {
        _findeksCreditRateRepository = findeksCreditRateRepository;
    }

    public async Task CheckFindeksCreditRateById(int id)
    {
        FindeksCreditRate? result = await _findeksCreditRateRepository.GetAsync(b => b.Id == id);

        if (result == null) throw new BusinessException(Messages.FindeksCreditRateDoesNotExist);
    }
}