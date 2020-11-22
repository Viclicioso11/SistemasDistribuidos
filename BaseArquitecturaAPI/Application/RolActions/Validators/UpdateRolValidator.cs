using Application.CandidateActions.Commands;
using Application.OptionActions.Commands;
using Application.RolActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Validators
{
    public class UpdateRolValidator : AbstractValidator<UpdateRolCommand>
    {
        public UpdateRolValidator()
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
