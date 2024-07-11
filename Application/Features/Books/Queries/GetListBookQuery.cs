using Application.Features.Books.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Logging;
using Core.Application.Requests;
using Core.Persistence.Paging;
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
    public class GetListBookQuery:IRequest<BookListModel>, ILoggableRequest
    {
        public PageRequest? PageRequest { get; set; }
    }
    public class GetListBookQueryHandler : IRequestHandler<GetListBookQuery, BookListModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetListBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookListModel> Handle(GetListBookQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Book> books =await _bookRepository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page,include: p => p.Include(p => p.BookShelf).Include(p => p.BookNotes));
            BookListModel mappedList=_mapper.Map<BookListModel>(books);
            return mappedList;
        }
    }
}
