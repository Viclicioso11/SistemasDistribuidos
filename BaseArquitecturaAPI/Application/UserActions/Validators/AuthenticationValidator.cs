using Application.UserActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.UserActions.Validators
{
    public class AuthenticationValidator : AbstractValidator<AuthenticationCommand>
    {
        public AuthenticationValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(a => a.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);
        }
    }
}
