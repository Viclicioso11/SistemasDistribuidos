using Application.UserActions.Commands;
using FluentValidation;

namespace Application.UserActions.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {

            RuleFor(v => v.User)
                .NotNull();

            When(c => c.User != null, () =>
            {
                RuleFor(c => c.User.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

                RuleFor(c => c.User.Identification)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(20);

                RuleFor(c => c.User.Names)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(50);

                RuleFor(c => c.User.LastNames)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(50);

                RuleFor(c => c.User.Password)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(20);
            });

        }
    }
}
