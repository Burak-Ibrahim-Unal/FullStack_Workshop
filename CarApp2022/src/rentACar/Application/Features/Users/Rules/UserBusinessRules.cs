using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        
        //Gerkhin 
        //cross cutting concern
        public async Task UserCanNotBeEmptyWhenSelected(int id)
        {
            var result = await _userRepository.GetAsync(user => user.Id == id);

            if (result == null) throw new BusinessException(Messages.UserDoesNotExist);
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.Email == email);

            if (result.Items.Any()) throw new BusinessException(Messages.UserEmailExists);
        }


    }
}
