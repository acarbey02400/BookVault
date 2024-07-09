using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Rules
{
    public class BookBusinessRules
    {
        public void BookShouldExistWhenRequest(Book? Book)
        {
            if (Book == null) throw new BusinessException("Requested Book does not exist.");
        }
    }
}
