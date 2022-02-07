using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class UpdateBrandCommand : IRequest<BrandUpdateDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, BrandUpdateDto>
    {
        private IBrandRepository _brandRepository;
        private IMapper _mapper;
        private BrandBusinessRules _brandBusinessRules;

        public UpdateBrandHandler(BrandBusinessRules brandBusinessRules, IBrandRepository brandRepository, IMapper mapper)
        {
            _brandBusinessRules = brandBusinessRules;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandUpdateDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToUpdate = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brandToUpdate == null)
                throw new BusinessException("Brand cannot found");

            await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

            _mapper.Map(brandToUpdate, request);
            await _brandRepository.UpdateAsync(brandToUpdate);
            var updatedBrand = _mapper.Map<BrandUpdateDto>(brandToUpdate);

            return updatedBrand;
        }
    }

}