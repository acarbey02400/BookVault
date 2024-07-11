using Core.Entities;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookNote:Entity
    {
        public int BookId { get; set; }
        public string Description { get; set; }
        public bool IsShared { get; set; }
        public virtual Book Book { get; set; }
        public ICollection<UserBookNote>? UserBookNotes { get; set; }
        public BookNote()
        {
            
        }

        public BookNote(int bookId, string description, bool isShared, ICollection<UserBookNote>? sharedUsers)
        {
            BookId = bookId;
            Description = description;
            IsShared = isShared;
            UserBookNotes = sharedUsers;
        }
    }
}
