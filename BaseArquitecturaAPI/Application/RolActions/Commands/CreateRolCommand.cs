using Application.RolActions.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.RolActions.Commands
{
    public class CreateRolCommand : IRequest<RolDto>
    {
       public Rol Rol { get; set; }
    }
}
