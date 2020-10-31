using Application.UserActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Commands
{
    public class AuthenticationCommand : IRequest<AuthenticationDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
