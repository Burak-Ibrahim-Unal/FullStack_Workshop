using Application.Features.Cars.Commands;
using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services.CarService;

public class CarManager : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarManager(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<Car> GetById(int id)
    {
        Car car = await _carRepository.GetAsync(c => c.Id == id);

        if (car == null) throw new BusinessException(Messages.CarDoesNotExist);

        return car;
    }

    public Task<Car> GetCarById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetFindexScoreById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UpdateCarDto> PickUpCar(Rental rental)
    {
        Car car = await _carRepository.GetAsync(c => c.Id == rental.CarId);
        car.Kilometer += Convert.ToInt32(rental.RentalEndKilometer - rental.RentalStartKilometer);
        car.CarState = CarState.Available;

        Car updatedCar = await _carRepository.UpdateAsync(car);
        UpdateCarDto updateCarDtoToReturn = _mapper.Map<UpdateCarDto>(updatedCar);
        return updateCarDtoToReturn;
    }

    public Task UpdateCar(UpdateCarCommand command)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCarAfterRentalEnd(DeliverRentalCarCommand command)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCarState(UpdateCarStateCommand command)
    {
        throw new NotImplementedException();
    }
}