using Application.RolActions.Commands;
using FluentValidation;

namespace Application.RolActions.Validators
{
    public class CreateRolValidator : AbstractValidator<CreateRolCommand>
    {
        public CreateRolValidator()
        {
            RuleFor(c => c.Rol)
                .NotNull();

            When(c => c.Rol != null, () =>
            {
                RuleFor(c => c.Rol.RolName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(15);

            });
        }
    }
}
