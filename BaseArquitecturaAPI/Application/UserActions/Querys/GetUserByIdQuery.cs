using Application.UserActions.Dtos;
using MediatR;

namespace Application.UserActions.Querys
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
