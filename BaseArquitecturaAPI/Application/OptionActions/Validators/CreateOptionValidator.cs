﻿using Application.OptionActions.Commands;
using FluentValidation;

namespace Application.OptionActions.Validators
{
    public class CreateOptionValidator : AbstractValidator<CreateOptionCommand>
    {
        public CreateOptionValidator()
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
