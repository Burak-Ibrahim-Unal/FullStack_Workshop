using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
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
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CheckEmailPresence(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException(Messages.UserDoesNotExist);
        }

        public async Task CheckEmailAbsence(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException(Messages.UserEmailExists);
        }

        public async Task CheckPasswords(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);

            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(Messages.PasswordError);
        }

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
