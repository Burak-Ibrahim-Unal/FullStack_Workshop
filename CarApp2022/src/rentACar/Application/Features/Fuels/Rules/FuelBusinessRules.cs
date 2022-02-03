using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Rules
{
    public class FuelBusinessRules
    {
        IFuelRepository _fuelRepository;

        public FuelBusinessRules(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }

        //Gerkhin 
        //cross cutting concern
        public async Task FuelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _fuelRepository.GetListAsync(fuel => fuel.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Fuel name exists...");
            }
        }


    }
}
