using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
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

namespace Application.Features.Cars.Queries
{
    public class GetCarListQuery : IRequest<CarListModel>
    {
        public PageRequest PageRequest { get; set; }

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
                IPaginate<CarListDto> cars = await _carRepository.GetAllCars(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                CarListModel mappedModels = _mapper.Map<CarListModel>(cars);

                return mappedModels;

            }
        }
    }
}