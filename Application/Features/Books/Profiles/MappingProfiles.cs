using Application.Features.Books.Commands.Create;
using Application.Features.Books.Commands.Update;
using Application.Features.Books.Dtos;
using Application.Features.Books.Models;
using Application.Features.Books.Queries;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book,CreateBookCommand>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();

            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            CreateMap<Book, GetByIdBookQuery>().ReverseMap();
            CreateMap<Book, BookGetByIdDto>().ForMember(p => p.BookShelfCode, x => x.MapFrom(c => c.BookShelf.ShelfCode)).ForMember(p=>p.BookNoteIds,x=>x.MapFrom(c=>c.BookNotes.Select(x=>x.Id).ToList())).ReverseMap();

            CreateMap<Book, BookGetListDto>().ForMember(p => p.BookShelfCode, x => x.MapFrom(c => c.BookShelf.ShelfCode)).ForMember(p => p.BookNoteIds, x => x.MapFrom(c => c.BookNotes.Select(x => x.Id).ToList())).ReverseMap();
            CreateMap<IPaginate<Book>, BookListModel>().ReverseMap();
        }
    }
}
