using Application.UserRolActions.Commands;
using FluentValidation;

namespace Application.UserRolActions.Validators
{
    public class CreateRolOptionValidator : AbstractValidator<CreateUserRolCommand>
    {
        public CreateRolOptionValidator()
        {
            RuleFor(c => c.IdUser)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.RolIds)
                .NotNull();

        }
    }
}
