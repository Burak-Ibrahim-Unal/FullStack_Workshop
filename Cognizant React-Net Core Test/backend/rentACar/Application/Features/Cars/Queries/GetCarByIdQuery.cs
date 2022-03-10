using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries;

public class GetCarByIdQuery : IRequest<CarDto>
{
    public int Id { get; set; }

    public class GetCarByIdResponseHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public GetCarByIdResponseHandler(ICarRepository carRepository, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }


        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {

            CarDto car = await _carRepository.GetCarById(request.Id);

            await _carBusinessRules.CheckCarDtoisNull(car);

            return car;
        }

    }
}