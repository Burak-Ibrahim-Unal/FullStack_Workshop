using Application.Features.Locations.Dtos;
using Application.Features.Locations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Commands
{
    public class CreateLocationCommand : IRequest<CreateLocationDto>
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }



        public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationDto>
        {
            private readonly ILocationRepository _locationRepository;
            private readonly IMapper _mapper;
            private readonly LocationBusinessRules _locationBusinessRules;
            private readonly ICacheService _cacheService;

            public CreateLocationCommandHandler(
                ILocationRepository locationRepository,
                IMapper mapper,
                LocationBusinessRules locationBusinessRules,
                ICacheService cacheService
            )
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
                _locationBusinessRules = locationBusinessRules;
                _cacheService = cacheService;

            }


            /// <summary>
            /// If location is created,cache will ve removed...Create method handler...
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessException"></exception>
            public async Task<CreateLocationDto> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
            {
                Location mappedLocation = _mapper.Map<Location>(request);
                Location createdLocation = await _locationRepository.AddAsync(mappedLocation);

                _cacheService.Remove("locations-list", "locations-list-available");

                CreateLocationDto locationDtoToReturn = _mapper.Map<CreateLocationDto>(createdLocation);
                return locationDtoToReturn;
            }

        }

    }
}
