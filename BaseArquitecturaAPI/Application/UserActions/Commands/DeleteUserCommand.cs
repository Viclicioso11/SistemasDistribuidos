using MediatR;
using System.Collections.Generic;

namespace Application.UserActions.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public List<int> Ids { get; set; }
    }
}
