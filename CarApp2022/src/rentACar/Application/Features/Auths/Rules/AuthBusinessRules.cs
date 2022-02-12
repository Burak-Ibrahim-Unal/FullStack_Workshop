using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Utilities;

namespace Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CheckUserEmailExist(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user == null) throw new BusinessException(Messages.UserDoesNotExist);
    }

    public async Task CheckUserEmailNotExist(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user != null) throw new BusinessException(Messages.UserEmailExists);
    }

    public async Task CheckUserPasswordMatch(int id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(Messages.PasswordError);
    }
}