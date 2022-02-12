using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries;

public class GetBrandByIdQuery : IRequest<BrandDto>
{
    public int Id { get; set; }

    public class GetByIdBrandResponseHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        IMapper _mapper;


        public GetByIdBrandResponseHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _brandBusinessRules = brandBusinessRules;
            _mapper = mapper;
        }


        public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.CheckBrandById(request.Id);

            Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
            BrandDto brandDtoToReturn = _mapper.Map<BrandDto>(brand);
            return brandDtoToReturn;
        }
    }
}