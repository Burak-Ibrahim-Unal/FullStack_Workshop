using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetCarByIdResponseHandler(ICarRepository carRepository, CarBusinessRules carBusinessRules, IMapper mapper)
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
            _mapper = mapper;
        }


        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CheckCarById(request.Id);

            Car car = await _carRepository.GetAsync(b => b.Id == request.Id);
            CarDto carDtoToReturn = _mapper.Map<CarDto>(car);

            return carDtoToReturn;
        }

    }
}