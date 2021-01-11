using Domain.Entities;
using MediatR;

namespace Application.VoteActions.Commands
{
    public class CreateVoteCommand : IRequest<bool>
    {
        public Vote Vote { get; set; }
    }
}
