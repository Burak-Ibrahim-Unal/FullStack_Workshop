using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
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
        public PageRequest pageRequest;

        public class GetListQueryHandler : IRequestHandler<GetCarListQuery, CarListModel>
        {
            ICarRepository _carRepository;
            IMapper _mapper;

            public GetListQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListQuery request, CancellationToken cancellationToken)
            {
                var cars = await _carRepository.GetListAsync(index: request.pageRequest.Page, size: request.pageRequest.PageSize);
                var mappedModels = _mapper.Map<CarListModel>(cars);

                return mappedModels;

            }
        }
    }
}