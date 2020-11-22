using Application.OptionActions.Dtos;
using Application.RolActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Commands
{
    public class CreateRolCommand : IRequest<RolDto>
    {
       public Rol Rol { get; set; }
    }
}
