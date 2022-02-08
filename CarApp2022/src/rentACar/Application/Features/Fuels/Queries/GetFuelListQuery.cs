using Application.Features.Fuels.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Queries.GetFuelList
{
    public class GetFuelListQuery : IRequest<FuelListModel>
    {
        public PageRequest pageRequest;

        public class GetListQueryHandler : IRequestHandler<GetFuelListQuery, FuelListModel>
        {
            IFuelRepository _colorRepository;
            IMapper _mapper;

            public GetListQueryHandler(IFuelRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<FuelListModel> Handle(GetFuelListQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetListAsync(
                    index: request.pageRequest.Page, 
                    size: request.pageRequest.PageSize);

                var mappedFuels = _mapper.Map<FuelListModel>(colors);

                return mappedFuels;

            }
        }
    }
}