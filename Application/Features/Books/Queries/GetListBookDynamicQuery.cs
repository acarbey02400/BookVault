using Application.Features.Books.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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
    public class GetListBookDynamicQuery : IRequest<BookListModel>
    {
        public PageRequest? PageRequest { get; set; }
        public Dynamic? Dynamic { get; set; }

        public class GetListTechnologyDynamicHandler : IRequestHandler<GetListBookDynamicQuery, BookListModel>
        {
            private readonly IBookRepository _repository;
            private readonly IMapper _mapper;

            public GetListTechnologyDynamicHandler(IBookRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<BookListModel> Handle(GetListBookDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Book> paginate = await _repository.GetListByDynamicAsync
                    (
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page,
                    include: p => p.Include(x => x.BookShelf).Include(x=>x.BookNotes),
                    dynamic: request.Dynamic
                    )
                    ;
                BookListModel mappedListModel = _mapper.Map<BookListModel>(paginate);
                return mappedListModel;
            }
        }
    }
}
