using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.RolOptionActions.Commands
{
    public class DeleteRolOptionCommand : IRequest<bool>
    {
        public List<RolOption> rolOptions { get; set; }

    }
}
