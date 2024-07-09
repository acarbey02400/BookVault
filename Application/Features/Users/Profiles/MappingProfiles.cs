using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries;
using AutoMapper;
using Core.Entities;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<User, GetByIdUserQuery>().ReverseMap();
            CreateMap<User, UserGetByIdDto>().ReverseMap();

            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
        }
    }
}
