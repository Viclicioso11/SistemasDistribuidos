using Application.VoteActions.Commands;
using FluentValidation;

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
