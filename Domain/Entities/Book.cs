using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book:Entity
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int BookShelfId { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public BookCategory Category { get; set; }
        public virtual BookShelf BookShelf { get; set; }
        public ICollection<BookNote>? BookNotes { get; set; }
        public Book()
        {
            
        }

        public Book(string name, string? ımageUrl, int bookShelfId, string? description, int stock, float price, BookCategory category, BookShelf bookShelf, ICollection<BookNote> bookNotes)
        {
            Name = name;
            ImageUrl = ımageUrl;
            BookShelfId = bookShelfId;
            Description = description;
            Stock = stock;
            Price = price;
            Category = category;
            BookShelf = bookShelf;
            BookNotes = bookNotes;
        }
    }
}
