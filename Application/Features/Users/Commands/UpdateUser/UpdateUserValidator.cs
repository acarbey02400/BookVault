using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(p=>p.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(p=>p.LastName).NotEmpty().MinimumLength(2);
            RuleFor(p=>p.Id).NotEmpty();
        }
    }
}
