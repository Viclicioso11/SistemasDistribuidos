using Application.RolOptionActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolOptionActions.Validators
{
    public class DeleteRolOptionValidator : AbstractValidator<DeleteRolOptionCommand>
    {
        public DeleteRolOptionValidator()
        {
            RuleFor(c => c.rolOptions)
                .NotNull()
                .NotEmpty();

        }
    }
}
