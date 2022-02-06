using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
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

namespace Application.Features.Models.Commands
{
    public class UpdateCarCommand : IRequest<ModelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }


        public class UpdateModelCommandHandler : IRequestHandler<UpdateCarCommand, ModelDto>
        {
            private IModelRepository _modelRepository;
            private IMapper _mapper;
            private ModelBusinessRules _modelBusinessRules;

            public UpdateModelCommandHandler(ModelBusinessRules modelBusinessRules, IModelRepository modelRepository, IMapper mapper)
            {
                _modelBusinessRules = modelBusinessRules;
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {

                var modelToUpdate = await _modelRepository.GetAsync(model => model.Id == request.Id);

                if (modelToUpdate == null) throw new BusinessException("model is not found");

                await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);
                await _modelBusinessRules.DailyPriceCanNotBeZero(request.DailyPrice);

                _mapper.Map(request, modelToUpdate);

                await _modelRepository.UpdateAsync(modelToUpdate);
                var updatedModel = _mapper.Map<ModelDto>(modelToUpdate);

                return updatedModel;
            }

        }

    }
}
