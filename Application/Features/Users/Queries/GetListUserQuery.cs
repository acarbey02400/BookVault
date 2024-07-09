using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Entities;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class GetListUserQuery : IRequest<UserListModel>
    {
        public PageRequest? PageRequest { get; set; }

        public class GetListUserHandler : IRequestHandler<GetListUserQuery, UserListModel>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;

            public GetListUserHandler(IUserRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> paginate = await _repository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page);
                UserListModel mappedListModel = _mapper.Map<UserListModel>(paginate);
                return mappedListModel;
            }
        }
    }
}
