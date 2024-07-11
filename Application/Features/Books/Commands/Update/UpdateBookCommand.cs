using Application.Features.Books.Dtos;
using Application.Features.Books.Rules;
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

namespace Application.Features.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest<UpdateBookDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int BookShelfId { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public float Price { get; set; }
        public int UpdatedById { get; set; }
        public BookCategory? Category { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

    }
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly BookBusinessRules _businessRules;
        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules businessRules)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? getBook =await _bookRepository.GetAsync(p => p.Id == request.Id);
            _businessRules.BookShouldExistWhenRequest(getBook);
            getBook.Name=request.Name==null?getBook.Name:request.Name;
            getBook.BookShelfId = request.BookShelfId == 0 || request.BookShelfId == null ? request.BookShelfId : getBook.BookShelfId;
            getBook.Stock=(int)(request.Stock==null?getBook.Stock:request.Stock);
            getBook.Description = request.Description;
            getBook.ImageUrl= request.ImageUrl==null?getBook.ImageUrl:request.ImageUrl;
            getBook.Category= (BookCategory)(request.Category==null?getBook.Category:request.Category);
            getBook.UpdatedDate=DateTime.Now;
            getBook.UpdatedById = request.UpdatedById;
            getBook.IsActive=(bool)(request.IsActive==null?getBook.IsActive:request.IsActive);
            getBook.IsDeleted=(bool)(request.IsDeleted==null?getBook.IsDeleted:request.IsDeleted);
            Book? updatedBook=await _bookRepository.UpdateAsync(getBook);
            Book UpdatedBook = await _bookRepository.AddAsync(updatedBook);
            UpdateBookDto mappedUpdatedBook = _mapper.Map<UpdateBookDto>(UpdatedBook);
            return mappedUpdatedBook;
        }
    }
}
