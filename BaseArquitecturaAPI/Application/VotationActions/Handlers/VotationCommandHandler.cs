using Application.VotationActions.Commands;
using Application.VotationActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VotationActions.Handlers
{
    public class VotationCommandHandler : IRequestHandler<VotationCommand, VotationDto>
    {
        public Task<VotationDto> Handle(VotationCommand request, CancellationToken cancellationToken)
        {
            // TO DO TO HANDLE REQUEST
            throw new NotImplementedException();
        }
    }
}
