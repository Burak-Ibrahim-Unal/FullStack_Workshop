using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarDamages.Queries;

public class GetCarDamageByIdQuery : IRequest<CarDamageDto>
{
    public int Id { get; set; }

    public class GetCarDamageByIdQueryHandler : IRequestHandler<GetCarDamageByIdQuery, CarDamageDto>
    {
        private readonly ICarDamageRepository _carDamageRepository;
        private readonly IMapper _mapper;
        private readonly CarDamageBusinessRules _carDamageBusinessRules;

        public GetCarDamageByIdQueryHandler(ICarDamageRepository carDamageRepository,
                                            CarDamageBusinessRules carDamageBusinessRules, IMapper mapper)
        {
            _carDamageRepository = carDamageRepository;
            _carDamageBusinessRules = carDamageBusinessRules;
            _mapper = mapper;
        }


        public async Task<CarDamageDto> Handle(GetCarDamageByIdQuery request, CancellationToken cancellationToken)
        {
            await _carDamageBusinessRules.CheckCarDamageById(request.Id);

            CarDamage carDamage = await _carDamageRepository.GetAsync(b => b.Id == request.Id);
            CarDamageDto carDamageDto = _mapper.Map<CarDamageDto>(carDamage);

            return carDamageDto;
        }
    }
}