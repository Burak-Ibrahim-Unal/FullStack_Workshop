using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetCarListByCityQuery : IRequest<CarListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public RentalOffice RentalOffice { get; set; }

        public string CacheKey => "cars-list";

        public bool BypassCache { get; set; }

        public TimeSpan? SlidingExpiration { get; set; }


        public class GetCarListByCityQueryHandler : IRequestHandler<GetCarListByCityQuery, CarListModel>
        {
            public readonly ICarRepository _carRepository;
            public readonly IMapper _mapper;

            public GetCarListByCityQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListByCityQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CarListDto> cars = await _carRepository.GetAllCarsByCity(
                    c => c.RentalOffice.Districts.ProvinceId == request.RentalOffice.Districts.ProvinceId,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                CarListModel mappedCars = _mapper.Map<CarListModel>(cars);
                return mappedCars;
            }
        }
    }
}
