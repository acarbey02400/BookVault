using Application.Features.UserBookNotes.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserBookNotes.Models
{
    public class UserBookNoteListModel : BasePageableModel
    {
        public IList<UserBookNoteGetListDto>? Items { get; set; }

    }
}
