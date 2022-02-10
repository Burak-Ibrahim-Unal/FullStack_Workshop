using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
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




        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarDto>
        {
            private ICarRepository _carRepository;
            private IMapper _mapper;
            private CarBusinessRules _carBusinessRules;

            public UpdateCarCommandHandler(CarBusinessRules carBusinessRules, ICarRepository carRepository, IMapper mapper)
            {
                _carBusinessRules = carBusinessRules;
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<UpdateCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {

                var carToUpdate = await _carRepository.GetAsync(car => car.Id == request.Id);

                if (carToUpdate == null) throw new BusinessException(Messages.CarDoesNotExist);

                await _carBusinessRules.CarPlateCanNotBeDuplicatedWhenInserted(request.Plate);
                await _carBusinessRules.ModelYearIsNotValid(request.ModelYear);
                await _carBusinessRules.CarCanNotBeRentWhenIsInMaintenance(request.ModelYear);

                _mapper.Map(request, carToUpdate);
                await _carRepository.UpdateAsync(carToUpdate);
                var updatedCar = _mapper.Map<UpdateCarDto>(carToUpdate);

                return updatedCar;
            }

        }

    }
}
