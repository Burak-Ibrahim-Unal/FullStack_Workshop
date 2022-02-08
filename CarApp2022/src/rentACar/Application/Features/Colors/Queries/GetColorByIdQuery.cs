using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetByIdColor;

public class GetFuelByIdQuery : IRequest<Color>
{
    public int Id { get; set; }

    public class GetColorByIdResponseHandler : IRequestHandler<GetFuelByIdQuery, Color>
    {
        private readonly IColorRepository _ColorRepository;
        private readonly ColorBusinessRules _ColorBusinessRules;

        public GetColorByIdResponseHandler(IColorRepository ColorRepository, ColorBusinessRules ColorBusinessRules)
        {
            _ColorRepository = ColorRepository;
            _ColorBusinessRules = ColorBusinessRules;
        }


        public async Task<Color> Handle(GetFuelByIdQuery request, CancellationToken cancellationToken)
        {
            await _ColorBusinessRules.ColorCanNotBeEmptyWhenSelected(request.Id);

            Color? Color = await _ColorRepository.GetAsync(b => b.Id == request.Id);
            return Color;
        }

    }
}