using Application.Features.BookNotes.Models;
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

namespace Application.Features.BookNotes.Queries
{
    public class GetListBookNoteQuery:IRequest<BookNoteListModel>, ILoggableRequest
    {
        public PageRequest? PageRequest { get; set; }

    }
    public class GetListBookNoteQueryHandler : IRequestHandler<GetListBookNoteQuery, BookNoteListModel>
    {
        private readonly IBookNoteRepository _bookNoteRepository;
        private readonly IMapper _mapper;
        public GetListBookNoteQueryHandler(IMapper mapper, IBookNoteRepository bookNoteRepository)
        {
            _mapper = mapper;
            _bookNoteRepository = bookNoteRepository;
        }
        public async Task<BookNoteListModel> Handle(GetListBookNoteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookNote> bookNotes= await _bookNoteRepository.GetListAsync(size:request.PageRequest.PageSize, index:request.PageRequest.Page,include:p=>p.Include(x=>x.UserBookNotes).Include(x=>x.Book));
            BookNoteListModel bookNoteList =_mapper.Map<BookNoteListModel>(bookNotes);
            return bookNoteList;
        }
    }
}
