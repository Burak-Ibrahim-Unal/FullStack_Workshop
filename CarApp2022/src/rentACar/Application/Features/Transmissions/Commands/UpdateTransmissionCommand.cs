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
    public class UpdateTransmissionCommand : IRequest<TransmissionUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, TransmissionUpdateDto>
        {
            private ITransmissionRepository _fuelRepository;
            private IMapper _mapper;
            private TransmissionBusinessRules _fuelBusinessRules;

            public UpdateTransmissionCommandHandler(TransmissionBusinessRules fuelBusinessRules, ITransmissionRepository fuelRepository, IMapper mapper)
            {
                _fuelBusinessRules = fuelBusinessRules;
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<TransmissionUpdateDto> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {

                var fuelToUpdate = await _fuelRepository.GetAsync(fuel => fuel.Id == request.Id);

                if (fuelToUpdate == null) throw new BusinessException(Messages.TransmissionDoesNotExist);

                await _fuelBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);

                _mapper.Map(request, fuelToUpdate);
                await _fuelRepository.UpdateAsync(fuelToUpdate);
                var updatedTransmission = _mapper.Map<TransmissionUpdateDto>(fuelToUpdate);

                return updatedTransmission;
            }

        }

    }
}
