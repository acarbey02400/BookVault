using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookShelfs.Dtos
{
    public class GetByIdBookShelfDto
    {
        public string ShelfCode { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime CreatedDate { get; set; } 
    }
}
