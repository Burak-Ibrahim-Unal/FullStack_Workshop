using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.MaintainCar;

public class MaintainCarCommand : IRequest<UpdateCarDto>
{
    public int Id { get; set; }

    public class MaintainCarCommandHandler : IRequestHandler<MaintainCarCommand, UpdateCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;
        private readonly ICacheService _cacheService;


        public MaintainCarCommandHandler(
            ICarRepository carRepository,
            CarBusinessRules carBusinessRules,
            IMapper mapper,
            ICacheService cacheService
        )
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<UpdateCarDto> Handle(MaintainCarCommand request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CheckCarById(request.Id);
            await _carBusinessRules.CheckCarByMaintenanceStatus(request.Id);

            Car updatedCar = await _carRepository.GetAsync(c => c.Id == request.Id);
            updatedCar.CarState = CarState.Maintenance;

            await _carRepository.UpdateAsync(updatedCar);
            _cacheService.Remove("cars-list");

            UpdateCarDto updatedCarDto = _mapper.Map<UpdateCarDto>(updatedCar);
            return updatedCarDto;
        }
    }
}