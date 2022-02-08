using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
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

namespace Application.Features.Transmissions.Commands
{
    public class CreateTransmissionCommand : IRequest<TransmissionCreateDto>
    {
        public string Name { get; set; }


        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, TransmissionCreateDto>
        {
            ITransmissionRepository _modelRepository;
            IMapper _mapper;
            TransmissionBusinessRules _modelBusinessRules;


            public CreateTransmissionCommandHandler(ITransmissionRepository modelRepository, IMapper mapper, TransmissionBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }


            public async Task<TransmissionCreateDto> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {

                await _modelBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedTransmission = _mapper.Map<Transmission>(request);
                var createdTransmission = await _modelRepository.AddAsync(mappedTransmission);

                var colorToReturn= _mapper.Map<TransmissionCreateDto>(request);
                return colorToReturn;
            }

        }

    }
}
