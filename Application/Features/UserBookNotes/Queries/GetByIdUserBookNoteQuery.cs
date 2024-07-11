using Application.Features.UserBookNotes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserBookNotes.Queries
{
    public class GetByIdUserBookNoteQuery : IRequest<UserBookNoteGetByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetByIdUserBookNoteQueryHandler : IRequestHandler<GetByIdUserBookNoteQuery, UserBookNoteGetByIdDto>
    {
        private readonly IUserBookNoteRepository _UserBookNoteRepository;
        private readonly IMapper _mapper;

        public GetByIdUserBookNoteQueryHandler(IUserBookNoteRepository UserBookNoteRepository, IMapper mapper)
        {
            _UserBookNoteRepository = UserBookNoteRepository;
            _mapper = mapper;
        }

        public async Task<UserBookNoteGetByIdDto> Handle(GetByIdUserBookNoteQuery request, CancellationToken cancellationToken)
        {
            var entity = await _UserBookNoteRepository.GetAsync(p => p.Id == request.Id);
            //BusinessRule
            UserBookNoteGetByIdDto mappedDto = _mapper.Map<UserBookNoteGetByIdDto>(entity);
            return mappedDto;
        }
    }
}
