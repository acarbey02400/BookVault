using Application.Features.Books.Dtos;
using Application.Features.Books.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries
{
    public class GetByIdBookQuery:IRequest<BookGetByIdDto>, ILoggableRequest
    {
        public int Id { get; set; }
    }
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, BookGetByIdDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly BookBusinessRules _bookBusinessRules;

        public GetByIdBookQueryHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules bookBusinessRules)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookBusinessRules = bookBusinessRules;
        }

        public async Task<BookGetByIdDto> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            Book? book = await _bookRepository.GetAsync(p => p.Id == request.Id,include:p=>p.Include(p=>p.BookShelf).Include(p=>p.BookNotes));
            _bookBusinessRules.BookShouldExistWhenRequest(book);
            BookGetByIdDto mappedDto=_mapper.Map<BookGetByIdDto>(book);
            return mappedDto;
        }
    }
}
