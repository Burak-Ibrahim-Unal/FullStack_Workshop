using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
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
    public class UpdateColorCommand : IRequest<UpdateColorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdateColorDto>
        {
            private IColorRepository _colorRepository;
            private IMapper _mapper;
            private ColorBusinessRules _colorBusinessRules;
            private readonly ICacheService _cacheService;


            public UpdateColorCommandHandler(
                ColorBusinessRules colorBusinessRules,
                IColorRepository colorRepository,
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _colorBusinessRules = colorBusinessRules;
                _colorRepository = colorRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            public async Task<UpdateColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                Color colorToUpdate = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToUpdate == null) throw new BusinessException(Messages.ColorDoesNotExist);

                colorToUpdate = _mapper.Map(request, colorToUpdate);
                await _colorRepository.UpdateAsync(colorToUpdate);

                _cacheService.Remove("colors-list");

                var updatedColor = _mapper.Map<UpdateColorDto>(colorToUpdate);
                return updatedColor;
            }

        }

    }
}
