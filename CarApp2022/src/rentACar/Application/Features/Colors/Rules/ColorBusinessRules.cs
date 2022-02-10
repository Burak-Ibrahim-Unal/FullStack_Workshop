using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Rules
{
    public class ColorBusinessRules
    {
        IColorRepository _colorRepository;


        public ColorBusinessRules(IColorRepository colorRepository)
        {

            _colorRepository = colorRepository;
        }

        //Gerkhin 
        //cross cutting concern
        public async Task ColorNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _colorRepository.GetListAsync(color => color.Name == name);

            if (result.Items.Any())
            {
                throw new BusinessException(Messages.ColorExists);
            }
        }     


        public async Task ColorCanNotBeEmptyWhenSelected(int id)
        {
            var result = await _colorRepository.GetAsync(color => color.Id == id);

            if (result == null) throw new BusinessException(Messages.ColorDoesNotExist);
        }



    }
}
