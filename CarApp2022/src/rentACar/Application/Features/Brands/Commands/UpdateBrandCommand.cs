using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class UpdateBrandCommand : IRequest<UpdateBrandDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandDto>
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

        public async Task<UpdateBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.CheckBrandByName(request.Name);

            var brandToUpdate = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brandToUpdate == null) throw new BusinessException(Messages.BrandDoesNotExist);

            Brand mappedBrand = _mapper.Map<Brand>(brandToUpdate);
            Brand updatedBrand = await _brandRepository.UpdateAsync(mappedBrand);

            UpdateBrandDto brandToReturn = _mapper.Map<UpdateBrandDto>(updatedBrand);
            return brandToReturn;
        }
    }

}