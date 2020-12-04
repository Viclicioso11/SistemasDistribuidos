using MediatR;
using System.Collections.Generic;

namespace Application.OptionActions.Commands
{
    public class DeleteOptionCommand : IRequest<bool>
    {
        public List<int> Ids { get; set; }
    }
}
