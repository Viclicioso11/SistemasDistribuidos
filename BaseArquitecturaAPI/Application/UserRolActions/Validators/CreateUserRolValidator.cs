using Application.RolOptionActions.Commands;
using Application.UserRolActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserRolActions.Validators
{
    public class CreateRolOptionValidator : AbstractValidator<CreateUserRolCommand>
    {
        public CreateRolOptionValidator()
        {
            RuleFor(c => c.IdUser)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.RolIds)
                .NotNull();

        }
    }
}
