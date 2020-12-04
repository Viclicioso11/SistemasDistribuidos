using Application.PoliticalPartyActions.Commands;
using FluentValidation;

namespace Application.PoliticalPartyActions.Validators
{
    public class CreatePoliticalPartyValidator : AbstractValidator<CreatePoliticalPartyCommand>
    {
        public CreatePoliticalPartyValidator()
        {
            RuleFor(c => c.PoliticalParty)
                .NotNull();

            When(c => c.PoliticalParty != null, () =>
            {
                RuleFor(c => c.PoliticalParty.Abreviation)
                .NotNull()
                .NotEmpty()
                .MaximumLength(6);

                RuleFor(c => c.PoliticalParty.PoliticalPartyName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(60);

                RuleFor(c => c.PoliticalParty.ImageUrl)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
            });
        }
    }
    
}
