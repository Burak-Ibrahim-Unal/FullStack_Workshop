using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries;

public class GetFuelByIdQuery : IRequest<FuelDto>
{
    public int Id { get; set; }

    public class GetFuelByIdResponseHandler : IRequestHandler<GetFuelByIdQuery, FuelDto>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly FuelBusinessRules _fuelBusinessRules;
        private readonly IMapper _mapper;

        public GetFuelByIdResponseHandler(IFuelRepository fuelRepository, FuelBusinessRules fuelBusinessRules, IMapper _mapper)
        {
            _fuelRepository = fuelRepository;
            _fuelBusinessRules = fuelBusinessRules;
            this._mapper = _mapper;
        }


        public async Task<FuelDto> Handle(GetFuelByIdQuery request, CancellationToken cancellationToken)
        {
            await _fuelBusinessRules.CheckFuelById(request.Id);

            Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);
            FuelDto fuelDtoToReturn = _mapper.Map<FuelDto>(fuel);
            return fuelDtoToReturn;
        }

    }
}