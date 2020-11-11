using Application.CandidateActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CandidateActions.Validators
{
    public class UpdateCandidateValidator : AbstractValidator<UpdateCandidateCommand>
    {
        public UpdateCandidateValidator()
        {
            RuleFor(c => c.Candidate)
                .NotNull();

            When(c => c.Candidate != null, () =>
            {
                RuleFor(c => c.Candidate.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

                RuleFor(c => c.Candidate.Surname)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

                RuleFor(c => c.Candidate.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

                RuleFor(c => c.Candidate.MiddleName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

            });
        }
    }
}
