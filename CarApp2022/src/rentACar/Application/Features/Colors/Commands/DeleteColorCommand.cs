﻿using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands
{
    public class DeleteFuelCommand : IRequest<FuelDeleteDto>
    {
        public int Id { get; set; }


        public class DeleteColorCommandHandler : IRequestHandler<DeleteFuelCommand, FuelDeleteDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<FuelDeleteDto> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var colorToDelete = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToDelete == null) throw new BusinessException(Messages.ColorNameDoesNotExist);

                await _colorRepository.DeleteAsync(colorToDelete);
                var colorToReturn = _mapper.Map<FuelDeleteDto>(colorToDelete);
                return colorToReturn;
            }
        }
    }
}
