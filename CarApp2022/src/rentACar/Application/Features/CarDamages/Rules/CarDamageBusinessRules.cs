using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;

namespace Application.Features.CarDamages.Rules;

public class CarDamageBusinessRules
{
    private readonly ICarDamageRepository _carDamageRepository;

    public CarDamageBusinessRules(ICarDamageRepository carDamageRepository)
    {
        _carDamageRepository = carDamageRepository;
    }
 
    public async Task CheckCarDamageById(int id)
    {
        CarDamage result = await _carDamageRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(Messages.CarDamageDoesNotExist);

    }
}
