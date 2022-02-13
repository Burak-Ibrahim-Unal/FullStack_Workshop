using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetByIdColor;

public class GetColorByIdQuery : IRequest<ColorDto>
{
    public int Id { get; set; }

    public class GetColorByIdResponseHandler : IRequestHandler<GetColorByIdQuery, ColorDto>
    {
        private readonly IColorRepository _ColorRepository;
        private readonly ColorBusinessRules _ColorBusinessRules;
        private readonly IMapper _mapper;

        public GetColorByIdResponseHandler(IColorRepository ColorRepository, ColorBusinessRules ColorBusinessRules, IMapper mapper)
        {
            _ColorRepository = ColorRepository;
            _ColorBusinessRules = ColorBusinessRules;
            _mapper = mapper;
        }


        public async Task<ColorDto> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
        {
            await _ColorBusinessRules.CheckColorById(request.Id);

            Color? Color = await _ColorRepository.GetAsync(b => b.Id == request.Id);

            ColorDto colorToReturn =  _mapper.Map<ColorDto>(Color);

            return colorToReturn;
        }

    }
}