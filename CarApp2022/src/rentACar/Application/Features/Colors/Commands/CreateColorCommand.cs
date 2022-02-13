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
    public class CreateColorCommand : IRequest<CreateColorDto>
    {
        public string Name { get; set; }


        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreateColorDto>
        {
            private readonly IColorRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ColorBusinessRules _modelBusinessRules;


            public CreateColorCommandHandler(IColorRepository modelRepository, IMapper mapper, ColorBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }


            public async Task<CreateColorDto> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {

                await _modelBusinessRules.CheckColorByName(request.Name);

                var mappedColor = _mapper.Map<Color>(request);

                var createdColor = await _modelRepository.AddAsync(mappedColor);

                var colorToReturn= _mapper.Map<CreateColorDto>(createdColor);

                return colorToReturn;
            }

        }

    }
}
