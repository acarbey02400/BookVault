using Application.Features.BookShelfs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Logging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookShelfs.Commands.CreateBookShelfs
{
    public class CreateBookShelfCommand:IRequest<CreateBookShelfDto>, ILoggableRequest
    {
        public string ShelfCode { get; set; }
        public string Location { get; set; }
        public int CreatedById { get; set; }
    }
    public class CreateBookShlefsCommandHanlder : IRequestHandler<CreateBookShelfCommand, CreateBookShelfDto>
    {
        private readonly IBookShelfRepository _bookShelfRepository;
        private readonly IMapper _mapper;

        public CreateBookShlefsCommandHanlder(IBookShelfRepository bookShelfRepository, IMapper mapper)
        {
            _bookShelfRepository = bookShelfRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookShelfDto> Handle(CreateBookShelfCommand request, CancellationToken cancellationToken)
        {
            BookShelf mappedRequest = _mapper.Map<BookShelf>(request);
            BookShelf createdBookShelf=await _bookShelfRepository.AddAsync(mappedRequest);
            CreateBookShelfDto mappedDto=_mapper.Map<CreateBookShelfDto>(createdBookShelf);
            return mappedDto;
        }
    }
}
