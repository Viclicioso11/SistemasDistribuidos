using Application.Votation.Commands;
using Application.Votation.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationHandler.Handlers
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
