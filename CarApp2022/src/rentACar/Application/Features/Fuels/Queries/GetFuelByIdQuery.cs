using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetByIdFuel;

public class GetFuelByIdQuery : IRequest<Fuel>
{
    public int Id { get; set; }

    public class GetFuelByIdResponseHandler : IRequestHandler<GetFuelByIdQuery, Fuel>
    {
        private readonly IFuelRepository _FuelRepository;
        private readonly FuelBusinessRules _FuelBusinessRules;

        public GetFuelByIdResponseHandler(IFuelRepository FuelRepository, FuelBusinessRules FuelBusinessRules)
        {
            _FuelRepository = FuelRepository;
            _FuelBusinessRules = FuelBusinessRules;
        }


        public async Task<Fuel> Handle(GetFuelByIdQuery request, CancellationToken cancellationToken)
        {
            await _FuelBusinessRules.FuelCanNotBeEmptyWhenSelected(request.Id);

            Fuel? Fuel = await _FuelRepository.GetAsync(b => b.Id == request.Id);
            return Fuel;
        }

    }
}