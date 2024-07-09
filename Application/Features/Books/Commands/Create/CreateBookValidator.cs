using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Create
{
    public class CreateBookValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
            RuleFor(p=>p.Category).NotEmpty();
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);
            RuleFor(p=>p.BookShelfId).NotEmpty();
        }
    }
}
