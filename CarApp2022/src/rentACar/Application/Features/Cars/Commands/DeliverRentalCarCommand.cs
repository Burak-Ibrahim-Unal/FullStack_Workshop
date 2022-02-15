using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands;

public class DeliverRentalCarCommand : IRequest<UpdateCarDto>
{
    public int Id { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public City City { get; set; }


    public class DeliverRentalCarCommandHandler : IRequestHandler<DeliverRentalCarCommand, UpdateCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;
        private readonly ICacheService _cacheService;



        public DeliverRentalCarCommandHandler(
            ICarRepository carRepository, 
            CarBusinessRules carBusinessRules,
            IMapper mapper,
            ICacheService cacheService
        )
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
            _mapper = mapper;
            _cacheService=cacheService;
        }

        public async Task<UpdateCarDto> Handle(DeliverRentalCarCommand request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CheckCarByMaintenanceStatus(request.Id);
            await _carBusinessRules.CheckCarByRentStatus(request.Id);

            Car carToUpdate = await _carRepository.GetAsync(c => c.Id == request.Id);
            carToUpdate.CarState = CarState.Rented;

            Car updatedCar = await _carRepository.UpdateAsync(carToUpdate);
            _cacheService.Remove("cars-list");

            UpdateCarDto updatedCarDto = _mapper.Map<UpdateCarDto>(updatedCar);
            return updatedCarDto;
        }
    }
}