using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class GetByIdUserQuery : IRequest<UserGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, UserGetByIdDto>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _businessRules;

            public GetByIdUserHandler(IUserRepository repository, IMapper mapper, UserBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _repository.GetAsync(p => p.Id == request.Id);
                _businessRules.UserShouldExistWhenRequest(user);
                UserGetByIdDto mappedUserGetByIdDto = _mapper.Map<UserGetByIdDto>(user);
                return mappedUserGetByIdDto;
            }
        }
    }
}
