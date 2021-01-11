using Application.UserActions.Dtos;
using MediatR;

namespace Application.UserActions.Commands
{
    public class AuthenticationCommand : IRequest<AuthenticationDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
