using Application.VotationActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.VotationActions.Validators
{
    public class CreateVotationValidator : AbstractValidator<CreateVotationCommand>
    {
        public CreateVotationValidator()
        {
            RuleFor(v => v.Votation)
                .NotNull();

            RuleFor(v => v.Candidates)
                .NotNull()
                .NotEmpty();

            When(c => c.Votation != null, () =>
            {
                RuleFor(c => c.Votation.CityId)
                .NotNull()
                .NotEmpty();

                RuleFor(c => c.Votation.VotationDescription)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

                RuleFor(c => c.Votation.VotationEndDate)
                .NotNull()
                .NotEmpty();

                RuleFor(c => c.Votation.VotationStartDate)
                .NotNull()
                .NotEmpty()
                .Must(v => v >= DateTime.Now);

                // validar que la fecha de fin sea mayor que la fecha de inicio 
                When(v => v.Votation.VotationEndDate != null && v.Votation.VotationStartDate != null, () =>
                {
                    RuleFor(v => v.Votation)
                     .Must(v => v.VotationStartDate < v.VotationEndDate);
                });

            });
        }
    }
}
