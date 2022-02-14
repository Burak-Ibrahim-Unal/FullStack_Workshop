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

public class DeleteCarDamageCommand : IRequest<DeleteCarDamageDto>
{
    public int Id { get; set; }

    public class DeleteCarDamageCommandHandler : IRequestHandler<DeleteCarDamageCommand, DeleteCarDamageDto>
    {
        private readonly ICarDamageRepository _carDamageRepository;
        private readonly IMapper _mapper;
        private readonly CarDamageBusinessRules _carDamageBusinessRules;
        private readonly ICacheService _cacheService;


        public DeleteCarDamageCommandHandler(
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

        public async Task<DeleteCarDamageDto> Handle(DeleteCarDamageCommand request,
                                                      CancellationToken cancellationToken)
        {
            CarDamage carDamageToDelete = await _carDamageRepository.GetAsync(x => x.Id == request.Id);
            if (carDamageToDelete == null) throw new BusinessException(Messages.CarDamageDoesNotExist);

            CarDamage deletedCarDamage = await _carDamageRepository.DeleteAsync(carDamageToDelete);
            _cacheService.Remove("car-damage-list");

            DeleteCarDamageDto deletedCarDamageDto = _mapper.Map<DeleteCarDamageDto>(deletedCarDamage);
            return deletedCarDamageDto;
        }
    }
}