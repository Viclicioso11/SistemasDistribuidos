using Application.RolOptionActions.Commands;
using Application.UserRolActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserRolActions.Validators
{
    public class DeleteRolOptionValidator : AbstractValidator<DeleteUserRolCommand>
    {
        public DeleteRolOptionValidator()
        {
            RuleFor(c => c.RolId)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.UserId)
                .NotNull()
                .NotEmpty();

        }
    }
}
