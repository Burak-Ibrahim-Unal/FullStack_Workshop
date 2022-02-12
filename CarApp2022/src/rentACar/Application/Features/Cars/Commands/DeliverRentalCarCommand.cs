using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands;

public class DeliverRentalCarCommand : IRequest<UpdateCarDto>
{
    public int Id { get; set; }

    public class DeliverRentalCarCommandHandler : IRequestHandler<DeliverRentalCarCommand, UpdateCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;


        public DeliverRentalCarCommandHandler(ICarRepository carRepository, CarBusinessRules carBusinessRules,
                                              IMapper mapper)
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateCarDto> Handle(DeliverRentalCarCommand request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CheckCarByMaintenanceStatus(request.Id);
            await _carBusinessRules.CheckCarByRentStatus(request.Id);

            Car? updatedCar = await _carRepository.GetAsync(c => c.Id == request.Id);
            updatedCar.CarState = CarState.Rented;

            await _carRepository.UpdateAsync(updatedCar);
            UpdateCarDto updatedCarDto = _mapper.Map<UpdateCarDto>(updatedCar);

            return updatedCarDto;
        }
    }
}