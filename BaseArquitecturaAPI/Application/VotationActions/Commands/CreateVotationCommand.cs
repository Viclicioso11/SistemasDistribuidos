using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.VotationActions.Commands
{
    public class CreateVotationCommand : IRequest<bool>
    {
        public Votation Votation { get; set; }

        public List<int> Candidates { get; set; }
    }
}
