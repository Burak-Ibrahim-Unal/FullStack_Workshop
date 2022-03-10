using Application.Features.Locations.Dtos;
using Application.Features.Locations.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Queries
{
    public class GetLocationListQuery : IRequest<LocationListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetLocationListQuery, LocationListModel>
        {
            public readonly ILocationRepository _locationRepository;
            public readonly IMapper _mapper;

            public GetListQueryHandler(ILocationRepository locationRepository, IMapper mapper)
            {
                _locationRepository = locationRepository;
                _mapper = mapper;
            }

            public async Task<LocationListModel> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LocationListDto> locations = await _locationRepository.GetAllLocations(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                LocationListModel mappedModels = _mapper.Map<LocationListModel>(locations);

                return mappedModels;

            }
        }
    }
}