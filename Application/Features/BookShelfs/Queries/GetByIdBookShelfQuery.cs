using Application.Features.BookShelfs.Dtos;
using Application.Features.BookShelfs.Rules;
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

namespace Application.Features.BookShelfs.Queries
{
    public class GetByIdBookShelfQuery:IRequest<GetByIdBookShelfDto>, ILoggableRequest
    {
        public int Id { get; set; }
    }

    public class GetByIdBookShlefsCommandHanlder : IRequestHandler<GetByIdBookShelfQuery, GetByIdBookShelfDto>
    {
        private readonly IBookShelfRepository _bookShelfRepository;
        private readonly IMapper _mapper;
        private readonly BookShelfBusinessRules _businessRules;

        public GetByIdBookShlefsCommandHanlder(IBookShelfRepository bookShelfRepository, IMapper mapper, BookShelfBusinessRules businessRules)
        {
            _bookShelfRepository = bookShelfRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetByIdBookShelfDto> Handle(GetByIdBookShelfQuery request, CancellationToken cancellationToken)
        {
            BookShelf? bookshelf = await _bookShelfRepository.GetAsync(p => p.Id == request.Id);
            _businessRules.BookShelfShouldExistWhenRequest(bookshelf);
            GetByIdBookShelfDto mappedDto = _mapper.Map<GetByIdBookShelfDto>(bookshelf);
            return mappedDto;
        }
    }
}
