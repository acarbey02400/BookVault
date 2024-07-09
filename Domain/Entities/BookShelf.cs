using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookShelf:Entity
    {
        public string ShelfCode { get; set; }
        public string Location { get; set; }
        public BookShelf()
        {
            
        }

        public BookShelf(string shelfCode, string location)
        {
            ShelfCode = shelfCode;
            Location = location;
        }
    }
}
