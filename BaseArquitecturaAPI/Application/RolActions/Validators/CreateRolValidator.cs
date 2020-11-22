using Application.OptionActions.Commands;
using Application.RolActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Validators
{
    public class CreateRolValidator : AbstractValidator<CreateRolCommand>
    {
        public CreateRolValidator()
        {
            RuleFor(c => c.Rol)
                .NotNull();

            When(c => c.Rol != null, () =>
            {
                RuleFor(c => c.Rol.RolName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

            });
        }
    }
}
