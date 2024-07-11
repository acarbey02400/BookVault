using Application.Features.BookNotes.Commands.Create;
using Application.Features.BookNotes.Dtos;
using Application.Features.BookNotes.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookNotes.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookNote,CreateBookNoteCommand>().ReverseMap();
            CreateMap<BookNote, CreateBookNoteDto>().ReverseMap();

            CreateMap<BookNote, GetByIdBookNoteQuery>().ReverseMap();
            CreateMap<BookNote, BookNoteGetByIdDto>().ForMember(p => p.UserBookNoteIds, x => x.MapFrom(c => c.UserBookNotes.Select(x=>x.Id).ToList())).ReverseMap();

        }
    }
}
