using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserBookNotes.Dtos
{
    public class CreateUserBookNoteDto
    {
        public int UserId { get; set; }
        public int BookNoteId { get; set; }
    }
}
