using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entities;
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
        public async Task CheckBrandExist(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(brand => brand.Name == name);

            if (result.Items.Any()) throw new BusinessException(Messages.BrandExists);
        }


        public async Task BrandCanNotBeEmptyWhenSelected(int id)
        {
            Brand result = await _brandRepository.GetAsync(brand => brand.Id == id);

            if (result == null) throw new BusinessException(Messages.BrandDoesNotExist);
        }


    }
}
