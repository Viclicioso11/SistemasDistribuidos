using MediatR;
using System.Collections.Generic;

namespace Application.RolActions.Commands
{
    public class DeleteRolCommand : IRequest<bool>
    {
        public List<int> Ids { get; set; }
    }
}
