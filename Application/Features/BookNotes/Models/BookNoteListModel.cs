using Application.Features.BookNotes.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookNotes.Models
{
    public class BookNoteListModel:BasePageableModel
    {
        public IList<BookNoteGetListDto>? Items { get; set; }

    }
}
