using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Rules
{
    public class ModelBusinessRules
    {
        IModelRepository _modelRepository;
        IBrandRepository _brandRepository;


        public ModelBusinessRules(IBrandRepository brandRepository, IModelRepository modelRepository)
        {
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
        }

        //Gerkhin 
        //cross cutting concern
        public async Task ModelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _modelRepository.GetListAsync(model => model.Name == name);

            if (result.Items.Any())
            {
                throw new BusinessException("Model name exists...");
            }
        }

        public async Task IsBrandExists(int brandId)
        {

            var result = await _brandRepository.GetAsync(x => x.Id == brandId);

            if (result == null)
            {
                throw new BusinessException("Brand doesnt exist");
            }
        }

        public Task DailyPriceCanNotBeZero(decimal price)
        {
            if (price <= 0)
            {
                throw new BusinessException("Daily price have to be higher than 0");
            }

            return Task.CompletedTask;
        }


        public async Task IsFuelExists(int fuelId)
        {
            var result = await _modelRepository.GetListAsync(b => b.Id == fuelId);

            if (result.Items.Any())
            {
                throw new BusinessException("Brand name exists");
            }
        }

        public async Task IsTransmissionExists(int trasmissionId)
        {
            var result = await _modelRepository.GetListAsync(b => b.Id == trasmissionId);

            if (result.Items.Any())
            {
                throw new BusinessException("Brand name exists");
            }
        }


    }
}
