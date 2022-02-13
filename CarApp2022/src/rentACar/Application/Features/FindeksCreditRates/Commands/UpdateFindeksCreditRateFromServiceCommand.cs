using Application.Features.FindeksCreditRates.Dtos;
using Application.Services;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Commands;

public class UpdateFindeksCreditRateFromServiceCommand : IRequest<UpdateFindeksCreditRateDto>
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; }

    public class UpdateFindeksCreditRateFromServiceCommandHandler : IRequestHandler<
        UpdateFindeksCreditRateFromServiceCommand,
        UpdateFindeksCreditRateDto>
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

        public async Task<UpdateFindeksCreditRateDto> Handle(UpdateFindeksCreditRateFromServiceCommand request,
                                                              CancellationToken cancellationToken)
        {
            var findeksCreditRate = await _findeksCreditRateRepository.GetAsync(f => f.Id == request.Id);

            var updatedFindeksCreditRate = await _findeksCreditRateRepository.UpdateAsync(findeksCreditRate);
            var updatedFindeksCreditRateDto =_mapper.Map<UpdateFindeksCreditRateDto>(updatedFindeksCreditRate);

            return updatedFindeksCreditRateDto;
        }
    }
}