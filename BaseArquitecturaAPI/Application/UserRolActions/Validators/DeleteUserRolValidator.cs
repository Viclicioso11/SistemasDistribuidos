using Application.UserRolActions.Commands;
using FluentValidation;

namespace Application.UserRolActions.Validators
{
    public class DeleteRolOptionValidator : AbstractValidator<DeleteUserRolCommand>
    {
        public DeleteRolOptionValidator()
        {
            RuleFor(c => c.RolId)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.UserId)
                .NotNull()
                .NotEmpty();

        }
    }
}
