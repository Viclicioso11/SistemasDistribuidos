using Application.VotationActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VotationActions.Validators
{
    public class VotationValidator : AbstractValidator<VotationCommand>
    {
        public VotationValidator()
        {
            RuleFor(v => v.CityId)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.VotationDescription)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.VotationEndDate)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.VotationStartDate)
                 .NotNull()
                 .NotEmpty();

            RuleFor(v => v.VotationTypeId)
                .NotNull()
                .NotEmpty();
        }
    }
}
