using Application.UserActions.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.UserActions.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public User User { get; set; }

        public int RolId { get; set; }
    }
}
