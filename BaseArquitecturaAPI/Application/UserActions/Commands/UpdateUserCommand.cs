using Application.UserActions.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.UserActions.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public User User { get; set; } 
    }
}
