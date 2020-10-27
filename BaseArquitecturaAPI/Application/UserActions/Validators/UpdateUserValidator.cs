using Application.UserActions.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(c => c.User.Email)
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(c => c.User.Identification)
                .MaximumLength(20);

            RuleFor(c => c.User.FirstName)
                .MaximumLength(15);

            RuleFor(c => c.User.MiddleName)
                .MaximumLength(15);

            RuleFor(c => c.User.LastName)
                .MaximumLength(15);

            RuleFor(c => c.User.Surname)
                .MaximumLength(20);

            RuleFor(c => c.User.Password)
                .MaximumLength(20);
        }
    }
}
