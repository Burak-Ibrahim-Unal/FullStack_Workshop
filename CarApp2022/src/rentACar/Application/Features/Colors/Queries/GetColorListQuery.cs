﻿using Application.Features.Colors.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Queries.GetColorList
{
    public class GetFuelListQuery : IRequest<ColorListModel>
    {
        public PageRequest pageRequest;

        public class GetListQueryHandler : IRequestHandler<GetFuelListQuery, ColorListModel>
        {
            IColorRepository _colorRepository;
            IMapper _mapper;

            public GetListQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<ColorListModel> Handle(GetFuelListQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetListAsync(
                    index: request.pageRequest.Page, 
                    size: request.pageRequest.PageSize);

                var mappedColors = _mapper.Map<ColorListModel>(colors);

                return mappedColors;

            }
        }
    }
}