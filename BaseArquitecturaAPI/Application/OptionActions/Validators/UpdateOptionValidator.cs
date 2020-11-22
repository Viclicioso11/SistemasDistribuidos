using Application.CandidateActions.Commands;
using Application.OptionActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptionActions.Validators
{
    public class UpdateOptionValidator : AbstractValidator<UpdateOptionCommand>
    {
        public UpdateOptionValidator()
        {
            RuleFor(c => c.Option)
                .NotNull();

            When(c => c.Option != null, () =>
            {
                RuleFor(c => c.Option.OptionName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

                RuleFor(c => c.Option.OptionDescription)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            });
        }
    }
}
