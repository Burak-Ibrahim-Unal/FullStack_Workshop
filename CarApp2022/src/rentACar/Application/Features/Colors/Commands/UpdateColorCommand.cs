using Application.Features.Colors.Dtos;
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
    public class UpdateFuelCommand : IRequest<FuelUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateColorCommandHandler : IRequestHandler<UpdateFuelCommand, FuelUpdateDto>
        {
            private IColorRepository _colorRepository;
            private IMapper _mapper;
            private ColorBusinessRules _colorBusinessRules;

            public UpdateColorCommandHandler(ColorBusinessRules colorBusinessRules, IColorRepository colorRepository, IMapper mapper)
            {
                _colorBusinessRules = colorBusinessRules;
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<FuelUpdateDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {

                var colorToUpdate = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToUpdate == null) throw new BusinessException(Messages.ColorNameDoesNotExist);

                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);

                _mapper.Map(request, colorToUpdate);
                await _colorRepository.UpdateAsync(colorToUpdate);
                var updatedColor = _mapper.Map<FuelUpdateDto>(colorToUpdate);

                return updatedColor;
            }

        }

    }
}
