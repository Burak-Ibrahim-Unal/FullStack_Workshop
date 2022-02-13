using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Commands;

public class DeleteFindeksCreditRateCommand : IRequest<FindeksCreditRateDeleteDto>
{
    public int Id { get; set; }

    public class
        DeleteFindeksCreditRateCommandHandler : IRequestHandler<DeleteFindeksCreditRateCommand,
            FindeksCreditRateDeleteDto>
    {
        private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
        private readonly IMapper _mapper;
        private readonly FindeksCreditRateBusinessRules _findeksCreditRateBusinessRules;

        public DeleteFindeksCreditRateCommandHandler(IFindeksCreditRateRepository findeksCreditRateRepository,
                                                     IMapper mapper,
                                                     FindeksCreditRateBusinessRules findeksCreditRateBusinessRules)
        {
            _findeksCreditRateRepository = findeksCreditRateRepository;
            _mapper = mapper;
            _findeksCreditRateBusinessRules = findeksCreditRateBusinessRules;
        }

        public async Task<FindeksCreditRateDeleteDto> Handle(DeleteFindeksCreditRateCommand request,
                                                              CancellationToken cancellationToken)
        {
            await _findeksCreditRateBusinessRules.CheckFindeksCreditRateById(request.Id);

            FindeksCreditRate mappedFindeksCreditRate = _mapper.Map<FindeksCreditRate>(request);
            FindeksCreditRate deletedFindeksCreditRate =
                await _findeksCreditRateRepository.DeleteAsync(mappedFindeksCreditRate);
            FindeksCreditRateDeleteDto deletedFindeksCreditRateDto =
                _mapper.Map<FindeksCreditRateDeleteDto>(deletedFindeksCreditRate);
            return deletedFindeksCreditRateDto;
        }
    }
}