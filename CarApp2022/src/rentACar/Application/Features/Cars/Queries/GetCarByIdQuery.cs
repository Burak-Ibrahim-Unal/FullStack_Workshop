using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries;

public class GetCarByIdQuery : IRequest<Car>
{
    public int Id { get; set; }

    public class GetCarByIdResponseHandler : IRequestHandler<GetCarByIdQuery, Car>
    {
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public GetCarByIdResponseHandler(ICarRepository carRepository, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }


        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CarCanNotBeEmptyWhenSelected(request.Id);

            var car = await _carRepository.GetAsync(b => b.Id == request.Id);
            return car;
        }

    }
}