using Application.Features.FindeksCreditRates.Dtos;
using Application.Services;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Commands;

public class UpdateFindeksCreditRateFromServiceCommand : IRequest<FindeksCreditRateUpdateDto>
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; }

    public class UpdateFindeksCreditRateFromServiceCommandHandler : IRequestHandler<
        UpdateFindeksCreditRateFromServiceCommand,
        FindeksCreditRateUpdateDto>
    {
        private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
        private readonly IMapper _mapper;

        public UpdateFindeksCreditRateFromServiceCommandHandler(
            IFindeksCreditRateRepository findeksCreditRateRepository,
            IMapper mapper)
        {
            _findeksCreditRateRepository = findeksCreditRateRepository;
            _mapper = mapper;
        }

        public async Task<FindeksCreditRateUpdateDto> Handle(UpdateFindeksCreditRateFromServiceCommand request,
                                                              CancellationToken cancellationToken)
        {
            var findeksCreditRate = await _findeksCreditRateRepository.GetAsync(f => f.Id == request.Id);

            var updatedFindeksCreditRate = await _findeksCreditRateRepository.UpdateAsync(findeksCreditRate);
            var updatedFindeksCreditRateDto =_mapper.Map<FindeksCreditRateUpdateDto>(updatedFindeksCreditRate);

            return updatedFindeksCreditRateDto;
        }
    }
}