using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetCarListQuery : IRequest<CarListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public string CacheKey => "cars-list";

        public bool BypassCache { get; set; }

        public TimeSpan? SlidingExpiration { get; set; }


        public class GetListQueryHandler : IRequestHandler<GetCarListQuery, CarListModel>
        {
            public readonly ICarRepository _carRepository;
            public readonly IMapper _mapper;

            public GetListQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Car> cars = await _carRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                CarListModel mappedModels = _mapper.Map<CarListModel>(cars);

                return mappedModels;

            }
        }
    }
}