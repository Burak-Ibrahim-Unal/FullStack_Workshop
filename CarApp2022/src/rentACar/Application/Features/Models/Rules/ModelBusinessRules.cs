using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
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


        public ModelBusinessRules(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        //Gerkhin 
        //cross cutting concern
        public async Task CheckModelByName(string name)
        {
            var result = await _modelRepository.GetListAsync(model => model.Name == name);

            if (result.Items.Any()) throw new BusinessException(Messages.ModelExists);
        }     


        public async Task CheckModelById(int id)
        {
            var result = await _modelRepository.GetAsync(model => model.Id == id);

            if (result == null) throw new BusinessException(Messages.ModelDoesNotExist);
        }
    }
}
