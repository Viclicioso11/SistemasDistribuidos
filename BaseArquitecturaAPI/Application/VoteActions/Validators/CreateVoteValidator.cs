using Application.OptionActions.Commands;
using Application.RolActions.Commands;
using Application.VoteActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Validators
{
    public class CreateVoteValidator : AbstractValidator<CreateVoteCommand>
    {
        public CreateVoteValidator()
        {
            RuleFor(c => c.Vote)
                .NotNull();

            When(c => c.Vote != null, () =>
            {
                RuleFor(c => c.Vote.CandidateId)
                .NotNull()
                .NotEmpty();

                RuleFor(c => c.Vote.UserId)
                .NotNull()
                .NotEmpty();

                RuleFor(c => c.Vote.VotationId)
                .NotNull()
                .NotEmpty();

            });
        }
    }
}
