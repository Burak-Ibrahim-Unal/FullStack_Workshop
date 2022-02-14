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
    public class DeleteColorCommand : IRequest<DeleteColorDto>
    {
        public int Id { get; set; }


        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeleteColorDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            private readonly ICacheService _cacheService;


            public DeleteColorCommandHandler(
                IColorRepository colorRepository,
                IMapper mapper,
                ICacheService cacheService
            )
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            public async Task<DeleteColorDto> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                Color colorToDelete = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToDelete == null) throw new BusinessException(Messages.ColorDoesNotExist);

                Color deletedColor = await _colorRepository.DeleteAsync(colorToDelete);
                _cacheService.Remove("colors-list");

                var colorToReturn = _mapper.Map<DeleteColorDto>(colorToDelete);
                return colorToReturn;
            }
        }
    }
}
