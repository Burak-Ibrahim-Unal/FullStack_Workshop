using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarDamages.Commands;

public class CreateCarDamageCommand : IRequest<CreateCarDamageDto>, ILoggableRequest
{
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsFixed { get; set; }


    public class CreateCarDamageCommandHandler : IRequestHandler<CreateCarDamageCommand, CreateCarDamageDto>
    {
        private readonly ICarDamageRepository _carDamageRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly CarDamageBusinessRules _carDamageBusinessRules;


        public CreateCarDamageCommandHandler(
            ICarDamageRepository carDamageRepository,
            IMapper mapper,
            CarDamageBusinessRules carDamageBusinessRules,
            ICacheService cacheService
        )
        {
            _carDamageRepository = carDamageRepository;
            _mapper = mapper;
            _cacheService = cacheService;
            _carDamageBusinessRules = carDamageBusinessRules;

        }

        public async Task<CreateCarDamageDto> Handle(CreateCarDamageCommand request,
                                                      CancellationToken cancellationToken)
        {

            CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);

            CarDamage createdCarDamage = await _carDamageRepository.AddAsync(mappedCarDamage);

            _cacheService.Remove("car-damage-list");

            CreateCarDamageDto createdCarDamageDto = _mapper.Map<CreateCarDamageDto>(createdCarDamage);

            return createdCarDamageDto;
        }
    }
}