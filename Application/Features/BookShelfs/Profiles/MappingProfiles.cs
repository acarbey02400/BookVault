using Application.Features.BookShelfs.Commands.CreateBookShelfs;
using Application.Features.BookShelfs.Dtos;
using Application.Features.BookShelfs.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookShelfs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookShelf, CreateBookShelfCommand>().ReverseMap();
            CreateMap<BookShelf, CreateBookShelfDto>().ReverseMap();

            CreateMap<BookShelf, GetByIdBookShelfQuery>().ReverseMap();
            CreateMap<BookShelf, GetByIdBookShelfDto>().ReverseMap();
        }
    }
}
