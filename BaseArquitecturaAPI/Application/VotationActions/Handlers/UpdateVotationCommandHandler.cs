using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VotationActions.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VotationActions.Handlers
{
    public class UpdateVotationCommandHandler : IRequestHandler<UpdateVotationCommand, bool>
    {
        private readonly IVotationService _votationService;
        
        public UpdateVotationCommandHandler(IVotationService votationSevice)
        {
            _votationService = votationSevice;
            
        }
        public async Task<bool> Handle(UpdateVotationCommand request, CancellationToken cancellationToken)
        {
            var result = await _votationService.UpdateVotation(request.Votation);

            if (!result)
                throw new ErrorException("02", $"Error tratando de actualizar votación con Id {request.Votation.Id}");

            return result;
        }
    }
}
