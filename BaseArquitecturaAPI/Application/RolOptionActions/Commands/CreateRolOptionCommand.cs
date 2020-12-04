using MediatR;
using System.Collections.Generic;

namespace Application.RolOptionActions.Commands
{
    public class CreateRolOptionCommand : IRequest<bool>
    {
        public int IdRol { get; set; }

        public List<int> OptionIds { get; set; }
    }
}
