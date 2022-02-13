using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarDamages.Commands;

public class UpdateCarDamageCommand : IRequest<UpdateCarDamageDto>
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Description { get; set; }
    public bool IsFixed { get; set; }

    public class UpdateCarDamageCommandHandler : IRequestHandler<UpdateCarDamageCommand, UpdateCarDamageDto>
    {
        private readonly ICarDamageRepository _carDamageRepository;
        private readonly IMapper _mapper;
        private readonly CarDamageBusinessRules _carDamageBusinessRules;

        public UpdateCarDamageCommandHandler(ICarDamageRepository carDamageRepository, IMapper mapper,
                                             CarDamageBusinessRules carDamageBusinessRules)
        {
            _carDamageRepository = carDamageRepository;
            _mapper = mapper;
            _carDamageBusinessRules = carDamageBusinessRules;
        }

        public async Task<UpdateCarDamageDto> Handle(UpdateCarDamageCommand request,
                                                      CancellationToken cancellationToken)
        {
            CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);
            CarDamage updatedCarDamage = await _carDamageRepository.UpdateAsync(mappedCarDamage);
            UpdateCarDamageDto updatedCarDamageDto = _mapper.Map<UpdateCarDamageDto>(updatedCarDamage);
            return updatedCarDamageDto;
        }
    }
}