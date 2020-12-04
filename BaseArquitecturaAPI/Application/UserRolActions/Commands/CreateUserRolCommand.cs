using MediatR;
using System.Collections.Generic;

namespace Application.UserRolActions.Commands
{
    public class CreateUserRolCommand : IRequest<bool>
    {
        public int IdUser { get; set; }

        public List<int> RolIds { get; set; }
    }
}
