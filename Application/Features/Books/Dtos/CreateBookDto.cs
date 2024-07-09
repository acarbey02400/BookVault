using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Dtos
{
    public class CreateBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int BookShelfId { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public BookCategory Category { get; set; }
    }
}
