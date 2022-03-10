using Application.Features.Locations.Dtos;
using Application.Features.Locations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Locations.Queries;

public class GetLocationByIdQuery : IRequest<LocationDto>
{
    public int Id { get; set; }

    public class GetLocationByIdResponseHandler : IRequestHandler<GetLocationByIdQuery, LocationDto>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly LocationBusinessRules _locationBusinessRules;

        public GetLocationByIdResponseHandler(ILocationRepository locationRepository, LocationBusinessRules locationBusinessRules)
        {
            _locationRepository = locationRepository;
            _locationBusinessRules = locationBusinessRules;
        }


        public async Task<LocationDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {

            LocationDto location = await _locationRepository.GetLocationById(request.Id);

            await _locationBusinessRules.CheckLocationDtoisNull(location);

            return location;
        }

    }
}