using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class UpdateCarCommand : IRequest<UpdateCarDto>
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }





        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarDto>
        {
            private ICarRepository _carRepository;
            private IMapper _mapper;
            private CarBusinessRules _carBusinessRules;
            private readonly ICacheService _cacheService;


            public UpdateCarCommandHandler(
                CarBusinessRules carBusinessRules, 
                ICarRepository carRepository, 
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _carBusinessRules = carBusinessRules;
                _carRepository = carRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            public async Task<UpdateCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {

                var carToUpdate = await _carRepository.GetAsync(car => car.Id == request.Id);

                if (carToUpdate == null) throw new BusinessException(Messages.CarDoesNotExist);

                Car updatedCar = await _carRepository.UpdateAsync(carToUpdate);
                _cacheService.Remove("cars-list");

                UpdateCarDto updatedCarDto = _mapper.Map<UpdateCarDto>(carToUpdate);
                return updatedCarDto;
            }

        }

    }
}
