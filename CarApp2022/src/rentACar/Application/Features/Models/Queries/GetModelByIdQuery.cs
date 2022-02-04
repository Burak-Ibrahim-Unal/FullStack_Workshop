using Application.Features.Models.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetByIdModel;

public class GetModelByIdQuery : IRequest<Model>
{
    public int Id { get; set; }

    public class GetModelByIdResponseHandler : IRequestHandler<GetModelByIdQuery, Model>
    {
        private readonly IModelRepository _ModelRepository;
        private readonly ModelBusinessRules _ModelBusinessRules;

        public GetModelByIdResponseHandler(IModelRepository ModelRepository, ModelBusinessRules ModelBusinessRules)
        {
            _ModelRepository = ModelRepository;
            _ModelBusinessRules = ModelBusinessRules;
        }


        public async Task<Model> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            await _ModelBusinessRules.ModelCanNotBeEmptyWhenSelected(request.Id);

            Model? Model = await _ModelRepository.GetAsync(b => b.Id == request.Id);
            return Model;
        }

    }
}