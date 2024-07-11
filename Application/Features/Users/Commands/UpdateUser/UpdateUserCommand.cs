
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Logging;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>, ILoggableRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Status { get; set; }
        public int Id { get; set; }

        public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            public UpdateUserHandler(IUserRepository UserRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = UserRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {

                User user = _userRepository.Get(p => p.Id == request.Id);//_mapper.Map<User>(request);
               _userBusinessRules.UserShouldExistWhenRequest(user);
                user.FirstName=request.FirstName==null?user.FirstName:request.FirstName;
                user.LastName=request.LastName==null?user.LastName:request.LastName;
                User updatedUser = await _userRepository.UpdateAsync(user);
                UpdateUserDto mappedUpdateUserDto = _mapper.Map<UpdateUserDto>(updatedUser);
                return mappedUpdateUserDto;
            }
        }
    }
}
