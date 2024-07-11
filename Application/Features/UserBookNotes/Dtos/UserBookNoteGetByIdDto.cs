using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserBookNotes.Dtos
{
    public class UserBookNoteGetByIdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookNoteId { get; set; }
    }
}
