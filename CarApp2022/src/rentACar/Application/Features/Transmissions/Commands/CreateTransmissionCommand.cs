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
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;
            private readonly TransmissionBusinessRules _transmissionBusinessRules;


            public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
                _transmissionBusinessRules = transmissionBusinessRules;
            }


            public async Task<TransmissionCreateDto> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {

                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);

                Transmission mappedTransmission = _mapper.Map<Transmission>(request);

                Transmission createdTransmission = await _transmissionRepository.AddAsync(mappedTransmission);

                TransmissionCreateDto transmissionToReturn = _mapper.Map<TransmissionCreateDto>(createdTransmission);

                return transmissionToReturn;
            }

        }

    }
}
