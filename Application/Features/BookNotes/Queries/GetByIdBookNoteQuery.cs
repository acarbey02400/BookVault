﻿using Application.Features.BookNotes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookNotes.Queries
{
    public class GetByIdBookNoteQuery:IRequest<BookNoteGetByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetByIdBookNoteQueryHandler : IRequestHandler<GetByIdBookNoteQuery, BookNoteGetByIdDto>
    {
        private readonly IBookNoteRepository _bookNoteRepository;
        private readonly IMapper _mapper;

        public GetByIdBookNoteQueryHandler(IBookNoteRepository bookNoteRepository, IMapper mapper)
        {
            _bookNoteRepository = bookNoteRepository;
            _mapper = mapper;
        }

        public async Task<BookNoteGetByIdDto> Handle(GetByIdBookNoteQuery request, CancellationToken cancellationToken)
        {
            var entity=await _bookNoteRepository.GetAsync(p=>p.Id==request.Id);
            //BusinessRule
            BookNoteGetByIdDto mappedDto=_mapper.Map<BookNoteGetByIdDto>(entity);
            return mappedDto;
        }
    }
}