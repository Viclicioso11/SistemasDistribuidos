using Application.VoteActions.Dtos;
using MediatR;


namespace Application.VoteActions.Querys
{
    public class GetVotesCountByVotationIdQuery : IRequest<VoteDto>
    {
        public int VotationId { get; set; }
    }
}
