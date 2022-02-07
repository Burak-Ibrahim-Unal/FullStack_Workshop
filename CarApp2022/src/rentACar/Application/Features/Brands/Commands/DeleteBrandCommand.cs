using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class DeleteBrandCommand : IRequest<BrandDeleteDto>
{
    public int Id { get; set; }

    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, BrandDeleteDto>
    {
        private IBrandRepository _brandRepository;
        private readonly IMapper _mapper;


        public DeleteBrandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandDeleteDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToDelete = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brandToDelete == null) throw new BusinessException("Brand cannot found");

            await _brandRepository.DeleteAsync(brandToDelete);
            var deletedCar = _mapper.Map<BrandDeleteDto>(brandToDelete);

            return deletedCar;
        }
    }
}