using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public List<int> Ids { get; set; }
    }
}
