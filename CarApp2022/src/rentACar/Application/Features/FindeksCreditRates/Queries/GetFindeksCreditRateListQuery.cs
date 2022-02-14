using Application.Features.FindeksCreditRates.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Queries;

public class GetFindeksCreditRateListQuery : IRequest<FindeksCreditRateListModel>
{
    public PageRequest PageRequest { get; set; }

    public class
        GetFindeksCreditRateListQueryHandler : IRequestHandler<GetFindeksCreditRateListQuery,
            FindeksCreditRateListModel>
    {
        private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
        private readonly IMapper _mapper;

        public GetFindeksCreditRateListQueryHandler(IFindeksCreditRateRepository findeksCreditRateRepository,
                                                    IMapper mapper)
        {
            _findeksCreditRateRepository = findeksCreditRateRepository;
            _mapper = mapper;
        }

        public async Task<FindeksCreditRateListModel> Handle(GetFindeksCreditRateListQuery request,
                                                             CancellationToken cancellationToken)
        {
            IPaginate<FindeksCreditRate> findeksCreditRates = await _findeksCreditRateRepository.GetListAsync(
                                                                  index: request.PageRequest.Page,
                                                                  size: request.PageRequest.PageSize
                                                                  );
            FindeksCreditRateListModel mappedFindeksCreditRateListModel =
                _mapper.Map<FindeksCreditRateListModel>(findeksCreditRates);

            return mappedFindeksCreditRateListModel;
        }
    }
}