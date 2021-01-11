using Application.VotationActions.Dtos;
using MediatR;

namespace Application.VotationActions.Querys
{
    public class GetVotationByIdQuery : IRequest<VotationDto>
    {
        public int VotationId { get; set; }
    }
}
