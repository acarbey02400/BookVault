using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookShelfs.Commands.CreateBookShelfs
{
    public class CreateBookShelfValidator:AbstractValidator<CreateBookShelfCommand>
    {
        public CreateBookShelfValidator()
        {
            RuleFor(p=>p.ShelfCode).NotEmpty().MinimumLength(2);
            RuleFor(p=>p.Location).NotEmpty().MinimumLength(2);
        }
    }
}
