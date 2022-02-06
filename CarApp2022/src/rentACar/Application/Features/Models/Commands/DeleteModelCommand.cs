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
    public class DeleteCarCommand : IRequest<Model>
    {
        public int Id { get; set; }


        public class DeleteModelCommandHandler : IRequestHandler<DeleteCarCommand, Model>
        {
            IModelRepository _modelRepository;

            public DeleteModelCommandHandler(IModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            public async Task<Model> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var modelToDelete = await _modelRepository.GetAsync(model => model.Id == request.Id);

                if (modelToDelete == null) throw new BusinessException("model is not found");

                await _modelRepository.DeleteAsync(modelToDelete);
                return modelToDelete;
            }

        }

    }
}
