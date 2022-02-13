using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarDamages.Commands;

public class CreateCarDamageCommand : IRequest<CreateCarDamageDto>
{
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsReady { get; set; }


    public class CreateCarDamageCommandHandler : IRequestHandler<CreateCarDamageCommand, CreateCarDamageDto>
    {
        private readonly ICarDamageRepository _carDamageRepository;
        private readonly IMapper _mapper;

        public CreateCarDamageCommandHandler(ICarDamageRepository carDamageRepository, IMapper mapper,CarDamageBusinessRules carDamageBusinessRules)
        {
            _carDamageRepository = carDamageRepository;
            _mapper = mapper;
        }

        public async Task<CreateCarDamageDto> Handle(CreateCarDamageCommand request,
                                                      CancellationToken cancellationToken)
        {

            CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);

            CarDamage createdCarDamage = await _carDamageRepository.AddAsync(mappedCarDamage);

            CreateCarDamageDto createdCarDamageDto = _mapper.Map<CreateCarDamageDto>(createdCarDamage);

            return createdCarDamageDto;
        }
    }
}