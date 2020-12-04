using MediatR;

namespace Application.VotationActions.Commands
{
    public class UpdateVotationStatusCommand : IRequest<bool>
    {
        public int VotationId { get; set; }

        public bool VotationStatus { get; set; }
    }
}
