using Application.RolOptionActions.Commands;
using FluentValidation;

namespace Application.RolOptionActions.Validators
{
    public class DeleteRolOptionValidator : AbstractValidator<DeleteRolOptionCommand>
    {
        public DeleteRolOptionValidator()
        {
            RuleFor(c => c.rolOptions)
                .NotNull()
                .NotEmpty();

        }
    }
}
