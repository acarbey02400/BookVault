using Application.Features.Books.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Create
{
    public class CreateBookCommand:IRequest<CreateBookDto>
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int BookShelfId { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public BookCategory Category { get; set; }
    }
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book mappedCommand=_mapper.Map<Book>(request);
            Book createdBook=await _bookRepository.AddAsync(mappedCommand);
            CreateBookDto mappedBook=_mapper.Map<CreateBookDto>(createdBook);
            return mappedBook;
        }
    }
}
