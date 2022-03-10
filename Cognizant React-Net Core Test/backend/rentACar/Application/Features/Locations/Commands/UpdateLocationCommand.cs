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
    public class UpdateLocationCommand : IRequest<UpdateLocationDto>
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }



        public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationDto>
        {
            private ILocationRepository _locationRepository;
            private IMapper _mapper;
            private LocationBusinessRules _locationBusinessRules;
            private readonly ICacheService _cacheService;


            public UpdateLocationCommandHandler(
                LocationBusinessRules locationBusinessRules,
                ILocationRepository locationRepository,
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _locationBusinessRules = locationBusinessRules;
                _locationRepository = locationRepository;
                _mapper = mapper;
                _cacheService= cacheService;
            }

            /// <summary>
            /// If location is update,cache will ve removed...Update method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<UpdateLocationDto> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
            {
                var updateLocationDto = await _locationRepository.GetLocationById(request.Id);

                if (updateLocationDto == null) throw new BusinessException(Messages.LocationDoesNotExist);

                Location locationToUpdate = _mapper.Map<Location>(request);

                await _locationRepository.UpdateAsync(locationToUpdate);

                _cacheService.Remove("locations-list", "locations-list-available", "locations-list-not-available", "locations-list-rented", "locations-list-under-maintenance");

                UpdateLocationDto updatedLocationDto = _mapper.Map<UpdateLocationDto>(locationToUpdate);
                return updatedLocationDto;
            }

        }

    }
}
