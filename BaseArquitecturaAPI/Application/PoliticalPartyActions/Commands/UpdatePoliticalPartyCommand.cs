using Application.PoliticalPartyActions.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.PoliticalPartyActions.Commands
{
    public class UpdatePoliticalPartyCommand : IRequest<PoliticalPartyDto>
    {
        public PoliticalParty PoliticalParty { get; set; }
    
    }
}
