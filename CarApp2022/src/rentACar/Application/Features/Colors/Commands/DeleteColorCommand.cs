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
    public class DeleteColorCommand : IRequest<Color>
    {
        public int Id { get; set; }


        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, Color>
        {
            IColorRepository _colorRepository;

            public DeleteColorCommandHandler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            public async Task<Color> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var colorToDelete = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToDelete == null) throw new BusinessException("color is not found");

                await _colorRepository.DeleteAsync(colorToDelete);
                return colorToDelete;
            }

        }

    }
}
