﻿using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands
{
    public class CreateModelCommand : IRequest<CreateModelDto>
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }


        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelDto>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ModelBusinessRules _modelBusinessRules;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<CreateModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.CheckModelByName(request.Name);

                var mappedModel = _mapper.Map<Model>(request);
                var createdModel = await _modelRepository.AddAsync(mappedModel);

                var modelDtoToReturn = _mapper.Map<CreateModelDto>(createdModel);
                return modelDtoToReturn;
            }

        }

    }
}
