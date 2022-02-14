using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarDamages.Commands;

public class UpdateCarDamageCommand : IRequest<UpdateCarDamageDto>
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsFixed { get; set; }

    public class UpdateCarDamageCommandHandler : IRequestHandler<UpdateCarDamageCommand, UpdateCarDamageDto>
    {
        private readonly ICarDamageRepository _carDamageRepository;
        private readonly IMapper _mapper;
        private readonly CarDamageBusinessRules _carDamageBusinessRules;
        private readonly ICacheService _cacheService;


        public UpdateCarDamageCommandHandler(
            ICarDamageRepository carDamageRepository,
            IMapper mapper,
            CarDamageBusinessRules carDamageBusinessRules,
            ICacheService cacheService
        )
        {
            _carDamageRepository = carDamageRepository;
            _mapper = mapper;
            _carDamageBusinessRules = carDamageBusinessRules;
            _cacheService = cacheService;
        }

        public async Task<UpdateCarDamageDto> Handle(UpdateCarDamageCommand request,
                                                      CancellationToken cancellationToken)
        {
            CarDamage? carDamageToUpdate = await _carDamageRepository.GetAsync(x => x.Id == request.Id);

            if (carDamageToUpdate == null) throw new BusinessException(Messages.CarDamageDoesNotExist);

            CarDamage updatedCarDamage = await _carDamageRepository.UpdateAsync(carDamageToUpdate);
            _cacheService.Remove("car-damage-list");

            UpdateCarDamageDto updatedCarDamageDto = _mapper.Map<UpdateCarDamageDto>(updatedCarDamage);
            return updatedCarDamageDto;
        }
    }
}