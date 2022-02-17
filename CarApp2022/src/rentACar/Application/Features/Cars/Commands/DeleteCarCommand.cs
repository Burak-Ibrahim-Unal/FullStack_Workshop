using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
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
    public class DeleteCarCommand : IRequest<DeleteCarDto>
    {
        public int Id { get; set; }


        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly ICacheService _cacheService;

            public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, ICacheService cacheService)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            public async Task<DeleteCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                Car carToDelete = await _carRepository.GetAsync(car => car.Id == request.Id);

                if (carToDelete == null) throw new BusinessException(Messages.CarDoesNotExist);

                Car DeletedCar = await _carRepository.DeleteAsync(carToDelete);
                _cacheService.Remove("cars-list");

                DeleteCarDto deletedCar = _mapper.Map<DeleteCarDto>(DeletedCar);
                return deletedCar;
            }

        }

    }
}
