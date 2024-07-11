using Application.Features.UserBookNotes.Commands.CreateUserBookNotes;
using Application.Features.UserBookNotes.Dtos;
using Application.Features.UserBookNotes.Models;
using Application.Features.UserBookNotes.Queries;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserBookNotes.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserBookNote, CreateUserBookNoteCommand>().ReverseMap();
            CreateMap<UserBookNote, CreateUserBookNoteDto>().ReverseMap();

            CreateMap<UserBookNote, UserBookNoteGetByIdDto>().ReverseMap();
            CreateMap<UserBookNote, UserBookNoteGetListDto>().ReverseMap();

            CreateMap<IPaginate<UserBookNote>, UserBookNoteListModel>().ReverseMap();
            CreateMap<UserBookNote, GetByIdUserBookNoteQuery>().ReverseMap();
        }
    }
}
