using Application.RolOptionActions.Commands;
using FluentValidation;

namespace Application.RolOptionActions.Validators
{
    public class CreateRolOptionValidator : AbstractValidator<CreateRolOptionCommand>
    {
        public CreateRolOptionValidator()
        {
            RuleFor(c => c.IdRol)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.OptionIds)
                .NotNull();

        }
    }
}
