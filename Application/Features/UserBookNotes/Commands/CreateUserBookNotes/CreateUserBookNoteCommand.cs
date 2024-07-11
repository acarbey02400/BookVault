using Application.Features.UserBookNotes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserBookNotes.Commands.CreateUserBookNotes
{
    public class CreateUserBookNoteCommand:IRequest<CreateUserBookNoteDto>
    {
        public int UserId { get; set; }
        public int BookNoteId { get; set; }
    }

    public class CreateUserBookNoteCommandHandler : IRequestHandler<CreateUserBookNoteCommand, CreateUserBookNoteDto>
    {
        private readonly IUserBookNoteRepository _userBookNoteRepository;
        private readonly IMapper _mapper;

        public CreateUserBookNoteCommandHandler(IUserBookNoteRepository userBookNoteRepository, IMapper mapper)
        {
            _userBookNoteRepository = userBookNoteRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserBookNoteDto> Handle(CreateUserBookNoteCommand request, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<UserBookNote>(request);
            UserBookNote userBookNote = await _userBookNoteRepository.AddAsync(mappedRequest);
            var mappedUserBookNote=_mapper.Map<CreateUserBookNoteDto>(userBookNote);
            return mappedUserBookNote;
        }
    }
}
