using Application.RolOptionActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolOptionActions.Validators
{
    public class CreateRolOptionValidator : AbstractValidator<CreateRolOptionCommand>
    {
        public CreateRolOptionValidator()
        {
            RuleFor(c => c.IdRol)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.OptionIds)
                .NotNull();

        }
    }
}
