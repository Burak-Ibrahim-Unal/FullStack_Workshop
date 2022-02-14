using Application.Features.Colors.Models;
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

namespace Application.Features.Colors.Queries.GetColorList
{
    public class GetColorListQuery : IRequest<ColorListModel>, ICachableRequest
    {
        public PageRequest? PageRequest { get; set; }

        public string CacheKey => "colors-list";

        public bool BypassCache { get; set; }

        public TimeSpan? SlidingExpiration { get; set; }


        public class GetListQueryHandler : IRequestHandler<GetColorListQuery, ColorListModel>
        {
            IColorRepository _colorRepository;
            IMapper _mapper;

            public GetListQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<ColorListModel> Handle(GetColorListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Color> colors = await _colorRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                ColorListModel mappedColors = _mapper.Map<ColorListModel>(colors);

                return mappedColors;

            }
        }
    }
}