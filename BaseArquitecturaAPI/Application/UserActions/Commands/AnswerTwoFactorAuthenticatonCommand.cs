using Application.UserActions.Dtos;
using MediatR;

namespace Application.UserActions.Commands
{
    public class AnswerTwoFactorAuthenticatonCommand : IRequest<TwoFactorAuthenticationDto>
    {
        public int AuthenticationId { get; set; }

        public string OneTimePassword { get; set; }

        public int UserId { get; set; }
    }
}
