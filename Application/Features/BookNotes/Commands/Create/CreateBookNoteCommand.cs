using Application.Features.BookNotes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Authorization;
using Core.Application.Logging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookNotes.Commands.Create
{
    public class CreateBookNoteCommand:IRequest<CreateBookNoteDto>, ILoggableRequest, ISecuredRequest
    {
        public string[] Roles => new string[] { "user" ,"admin"};
        public int BookId { get; set; }
        public string Description { get; set; }
        public bool IsShared { get; set; }
    }
    public class CreateBookNoteCommandHandler : IRequestHandler<CreateBookNoteCommand, CreateBookNoteDto>
    {
        private readonly IBookNoteRepository _bookNoteRepository;
        private readonly IMapper _mapper;

        public CreateBookNoteCommandHandler(IBookNoteRepository bookNoteRepository, IMapper mapper)
        {
            _bookNoteRepository = bookNoteRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookNoteDto> Handle(CreateBookNoteCommand request, CancellationToken cancellationToken)
        {
            BookNote mappedRequest = _mapper.Map<BookNote>(request);
           BookNote createdBookNote=await _bookNoteRepository.AddAsync(mappedRequest);
            CreateBookNoteDto mappedDto=_mapper.Map<CreateBookNoteDto>(createdBookNote);
            return mappedDto;
        }
    }
}
