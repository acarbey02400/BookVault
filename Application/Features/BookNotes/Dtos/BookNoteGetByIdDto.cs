using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookNotes.Dtos
{
    public class BookNoteGetByIdDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public bool IsShared { get; set; }
        public IList<int> UserBookNoteIds { get; set; }
    }
}
