using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities;
using Core.Security.Dtos;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Email already exists!");
        }

        public async Task<User> IsEmailOrPasswordRegistered(UserForLoginDto userForLoginDto)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == userForLoginDto.Email);
            if (user == null) throw new BusinessException("Email not found");
            bool isVerified = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isVerified) throw new BusinessException("Wrong password");
            return user;
        }

    }
}
