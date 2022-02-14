using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class DeleteBrandCommand : IRequest<DeleteBrandDto> 
{
    public int Id { get; set; }

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, ICacheService cacheService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<DeleteBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brandToDelete = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brandToDelete == null) throw new BusinessException(Messages.BrandDoesNotExist);

            Brand deletedBrand = await _brandRepository.DeleteAsync(brandToDelete);
            _cacheService.Remove("brands-list");

            DeleteBrandDto deletedBrandDto = _mapper.Map<DeleteBrandDto>(deletedBrand);
            return deletedBrandDto;
        }
    }
}

