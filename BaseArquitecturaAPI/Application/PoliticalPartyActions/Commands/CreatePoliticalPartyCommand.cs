using Application.PoliticalPartyActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PoliticalPartyActions.Commands
{
    public class CreatePoliticalPartyCommand : IRequest<PoliticalPartyDto>
    {
        public PoliticalParty PoliticalParty { get; set; }
    }
}
