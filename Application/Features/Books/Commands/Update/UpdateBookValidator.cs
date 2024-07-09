using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Update
{
    public class UpdateBookValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Category).NotEmpty();
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);
            RuleFor(p => p.BookShelfId).NotEmpty();
        }
    }
}
