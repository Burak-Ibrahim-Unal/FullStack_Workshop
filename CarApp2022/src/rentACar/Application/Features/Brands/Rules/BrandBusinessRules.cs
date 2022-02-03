using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        //Gerkhin 
        //cross cutting concern
        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _brandRepository.GetListAsync(brand => brand.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Brand name exists...");
            }
        }

        public async Task BrandIdShouldExistWhenSelected(int id)
        {
            var result = await _brandRepository.GetAsync(brand => brand.Id == id);
            if (result == null) throw new BusinessException("Brand not exists.");
        }


    }
}
