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

            /// <summary>
            /// If car is deleted,cache will ve removed...Delete method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<DeleteCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {

                var deletedCarDto = await _carRepository.GetCarById(request.Id);

                if (deletedCarDto == null) throw new BusinessException(Messages.CarDoesNotExist);

                Car carToDelete = _mapper.Map<Car>(request);
                await _carRepository.DeleteAsync(carToDelete);


                _cacheService.Remove("cars-list", "cars-list-available", "cars-list-not-available", "cars-list-rented", "cars-list-under-maintenance");


                DeleteCarDto returnToDeletedCarDto = _mapper.Map<DeleteCarDto>(deletedCarDto);
                return returnToDeletedCarDto;

            }

        }

    }
}
