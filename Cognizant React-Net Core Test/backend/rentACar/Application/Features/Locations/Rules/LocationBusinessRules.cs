using Application.Features.Locations.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Rules
{
    public class LocationBusinessRules
    {
        private readonly ILocationRepository _locationRepository;

        public LocationBusinessRules(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }


        public async Task CheckLocationDtoisNull(LocationDto locationDto)
        {
            if (locationDto == null) throw new BusinessException(Messages.LocationDoesNotExist);
        }

    }


}

