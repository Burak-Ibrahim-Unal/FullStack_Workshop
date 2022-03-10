using Application.Features.Locations.Dtos;
using Application.Features.Locations.Rules;
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

namespace Application.Features.Locations.Commands
{
    public class DeleteLocationCommand : IRequest<DeleteLocationDto>
    {
        public int Id { get; set; }


        public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationDto>
        {
            private readonly ILocationRepository _locationRepository;
            private readonly IMapper _mapper;
            private readonly ICacheService _cacheService;


            public DeleteLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper, ICacheService cacheService)
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            /// <summary>
            /// If location is deleted,cache will ve removed...Delete method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<DeleteLocationDto> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
            {

                var deletedLocationDto = await _locationRepository.GetLocationById(request.Id);

                if (deletedLocationDto == null) throw new BusinessException(Messages.LocationDoesNotExist);

                Location locationToDelete = _mapper.Map<Location>(request);
                await _locationRepository.DeleteAsync(locationToDelete);


                _cacheService.Remove("locations-list", "locations-list-available", "locations-list-not-available", "locations-list-rented", "locations-list-under-maintenance");


                DeleteLocationDto returnToDeletedLocationDto = _mapper.Map<DeleteLocationDto>(deletedLocationDto);
                return returnToDeletedLocationDto;

            }

        }

    }
}
