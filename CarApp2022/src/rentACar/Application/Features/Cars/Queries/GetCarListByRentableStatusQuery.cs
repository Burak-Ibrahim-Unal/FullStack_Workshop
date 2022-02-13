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

namespace Application.Features.Cars.Queries.GetCar
{
    public class GetCarListByRentableStatusQuery : IRequest<CarListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache => throw new NotImplementedException();

        public string CacheKey => "rentable-cars-list";

        public TimeSpan? SlidingExpiration => throw new NotImplementedException();


        public class GetCarListByRentableStatusQueryHandler : IRequestHandler<GetCarListByRentableStatusQuery, CarListModel>
        {
            public readonly ICarRepository _carRepository;
            public readonly IMapper _mapper;

            public GetCarListByRentableStatusQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListByRentableStatusQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Car> cars = await _carRepository.GetListAsync(
                    car => car.CarState == CarState.Available,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                CarListModel mappedCars = _mapper.Map<CarListModel>(cars);
                return mappedCars;
            }
        }
    }
}
