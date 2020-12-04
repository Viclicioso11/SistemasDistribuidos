using Application.PoliticalPartyActions.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.PoliticalPartyActions.Commands
{
    public class CreatePoliticalPartyCommand : IRequest<PoliticalPartyDto>
    {
        public PoliticalParty PoliticalParty { get; set; }
    }
}
