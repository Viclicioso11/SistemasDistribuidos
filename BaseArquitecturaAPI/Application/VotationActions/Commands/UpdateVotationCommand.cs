using Domain.Entities;
using MediatR;

namespace Application.VotationActions.Commands
{
    public class UpdateVotationCommand : IRequest<bool>
    {
        public Votation Votation { get; set; }
    }
}
