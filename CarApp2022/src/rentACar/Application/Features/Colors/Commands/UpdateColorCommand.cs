using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands
{
    public class UpdateColorCommand : IRequest<ColorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, ColorDto>
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

            public async Task<ColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {

                var colorToUpdate = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToUpdate == null) throw new BusinessException("color is not found");

                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);

                _mapper.Map(request, colorToUpdate);

                await _colorRepository.UpdateAsync(colorToUpdate);
                var updatedColor = _mapper.Map<ColorDto>(colorToUpdate);

                return updatedColor;
            }

        }

    }
}
