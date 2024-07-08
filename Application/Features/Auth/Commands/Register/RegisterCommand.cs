using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Entities;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto? UserForRegisterDto { get; set; }
        public string? IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
                User createdUser = await _userRepository.AddAsync(new User
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                });
                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);



                return new RegisteredDto { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            }
        }
    }
}
