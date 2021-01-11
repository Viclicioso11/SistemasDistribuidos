using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VotationActions.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VotationActions.Handlers
{
    public class UpdateVotationStatusCommandHandler : IRequestHandler<UpdateVotationStatusCommand, bool>
    {
        private readonly IVotationService _votationService;
        public UpdateVotationStatusCommandHandler(IVotationService votationService)
        {
            _votationService = votationService;
        }
        public async Task<bool> Handle(UpdateVotationStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _votationService.UpdateVotationStatus(request.VotationStatus, request.VotationId);

            if (!result)
                throw new ErrorException("02", $"Error tratando de actualizar estado de la votación con Id {request.VotationId}");

            return result;
        }
    }
}
