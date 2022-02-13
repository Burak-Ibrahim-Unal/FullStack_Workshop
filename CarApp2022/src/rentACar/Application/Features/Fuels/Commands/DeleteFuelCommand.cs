using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
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

namespace Application.Features.Fuels.Commands
{
    public class DeleteFuelCommand : IRequest<DeleteFuelDto>
    {
        public int Id { get; set; }


        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeleteFuelDto>
        {
            private readonly IFuelRepository _colorRepository;
            private readonly IMapper _mapper;

            public DeleteFuelCommandHandler(IFuelRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<DeleteFuelDto> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var colorToDelete = await _colorRepository.GetAsync(color => color.Id == request.Id);

                if (colorToDelete == null) throw new BusinessException(Messages.FuelDoesNotExist);

                await _colorRepository.DeleteAsync(colorToDelete);
                var colorToReturn = _mapper.Map<DeleteFuelDto>(colorToDelete);
                return colorToReturn;
            }
        }
    }
}
