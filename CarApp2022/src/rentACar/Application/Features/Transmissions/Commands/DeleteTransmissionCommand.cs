using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
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

namespace Application.Features.Transmissions.Commands
{
    public class DeleteTransmissionCommand : IRequest<TransmissionDeleteDto>
    {
        public int Id { get; set; }


        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, TransmissionDeleteDto>
        {
            private readonly ITransmissionRepository _colorRepository;
            private readonly IMapper _mapper;

            public DeleteTransmissionCommandHandler(ITransmissionRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<TransmissionDeleteDto> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                var colorToDelete = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToDelete == null) throw new BusinessException(Messages.TransmissionDoesNotExist);

                await _colorRepository.DeleteAsync(colorToDelete);
                var colorToReturn = _mapper.Map<TransmissionDeleteDto>(colorToDelete);
                return colorToReturn;
            }
        }
    }
}
