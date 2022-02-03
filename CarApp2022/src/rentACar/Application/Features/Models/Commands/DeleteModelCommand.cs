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

namespace Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommand : IRequest<Model>
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        //public decimal DailyPrice { get; set; }
        //public int BrandId { get; set; }
        //public int TransmissionId { get; set; }
        //public int FuelId { get; set; }
        //public string ImageUrl { get; set; }


        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, Model>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;
            ModelBusinessRules _modelBusinessRules;

            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<Model> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                //await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);
                //await _modelBusinessRules.IsBrandExists(request.BrandId);
                //await _modelBusinessRules.IsFuelExists(request.FuelId);
                //await _modelBusinessRules.IsTransmissionExists(request.TransmissionId);
                //await _modelBusinessRules.DailyPriceCanNotBeZero(request.DailyPrice);

                var deletedModel = await _modelRepository.DeleteAsync(model => model.Id == request.Id);
                if (deletedModel == null) throw new BusinessException("model is not found");
                await

                var mappedModel = _mapper.Map<Model>(request);

                var createdModel = await _modelRepository.AddAsync(mappedModel);
                return createdModel;
            }

        }

    }
}
