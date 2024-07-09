using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookShelfs.Rules
{
    public class BookShelfBusinessRules
    {
        public void BookShelfShouldExistWhenRequest(BookShelf? BookShelf)
        {
            if (BookShelf == null) throw new BusinessException("Requested Book does not exist.");
        }
    }
}
