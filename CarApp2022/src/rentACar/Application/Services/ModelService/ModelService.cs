﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ModelService
{
    public class ModelService : IModelService
    {
        public IModelRepository modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }

        public async Task<double> GetDailyPriceById(int modelId)
        {
            var result = await modelRepository.GetAsync(m => m.Id == modelId);

            if (result is null)
            {
                throw new RepositoryException(Messages.ModelDoesNotExist);
            }
            return result.DailyPrice;
        }
    }
}
