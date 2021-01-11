using Application.PoliticalPartyActions.Dtos;
using MediatR;

namespace Application.PoliticalPartyActions.Querys
{
    public class GetPoliticalPartyByIdQuery : IRequest<PoliticalPartyDto>
    {
        public int Id { get; set; }
    }
}
