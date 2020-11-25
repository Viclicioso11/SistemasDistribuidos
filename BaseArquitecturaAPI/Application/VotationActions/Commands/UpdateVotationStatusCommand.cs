using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VotationActions.Commands
{
    public class UpdateVotationStatusCommand : IRequest<bool>
    {
        public int VotationId { get; set; }

        public bool VotationStatus { get; set; }
    }
}
