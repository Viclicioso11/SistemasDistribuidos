using Application.PoliticalPartyActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PoliticalPartyActions.Querys
{
    public class GetPoliticalPartyByIdQuery : IRequest<PoliticalPartyDto>
    {
        public int Id { get; set; }
    }
}
