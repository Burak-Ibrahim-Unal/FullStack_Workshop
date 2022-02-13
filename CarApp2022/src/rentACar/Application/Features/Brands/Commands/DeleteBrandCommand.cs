using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand : IRequest<DeleteBrandDto>
{
    public int Id { get; set; }

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brandToDelete = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brandToDelete == null) throw new BusinessException(Messages.BrandDoesNotExist);

            Brand mappedBrand = _mapper.Map<Brand>(request);
            Brand deletedBrand = await _brandRepository.DeleteAsync(mappedBrand);

            DeleteBrandDto deletedBrandDto = _mapper.Map<DeleteBrandDto>(deletedBrand);
            return deletedBrandDto;
        }
    }
}

