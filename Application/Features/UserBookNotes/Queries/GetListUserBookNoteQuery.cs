using Application.Features.UserBookNotes.Models;
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

namespace Application.Features.UserBookNotes.Queries
{
    public class GetListUserBookNoteQuery : IRequest<UserBookNoteListModel>, ILoggableRequest
    {
        public PageRequest? PageRequest { get; set; }

    }
    public class GetListUserBookNoteQueryHandler : IRequestHandler<GetListUserBookNoteQuery, UserBookNoteListModel>
    {
        private readonly IUserBookNoteRepository _UserBookNoteRepository;
        private readonly IMapper _mapper;
        public GetListUserBookNoteQueryHandler(IMapper mapper, IUserBookNoteRepository UserBookNoteRepository)
        {
            _mapper = mapper;
            _UserBookNoteRepository = UserBookNoteRepository;
        }
        public async Task<UserBookNoteListModel> Handle(GetListUserBookNoteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserBookNote> UserBookNotes = await _UserBookNoteRepository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page, include: p => p.Include(x => x.BookNote).Include(x => x.User));
            UserBookNoteListModel UserBookNoteList = _mapper.Map<UserBookNoteListModel>(UserBookNotes);
            return UserBookNoteList;
        }
    }
}

