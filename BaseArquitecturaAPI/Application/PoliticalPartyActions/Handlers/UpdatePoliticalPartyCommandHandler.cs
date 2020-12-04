using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.PoliticalPartyActions.Commands;
using Application.PoliticalPartyActions.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PoliticalPartyActions.Handlers
{
    public class UpdatePoliticalPartyCommandHandler : IRequestHandler<UpdatePoliticalPartyCommand, PoliticalPartyDto>
    {
        private readonly IPoliticalPartyService _service;
        private readonly IMapper _mapper;
        public UpdatePoliticalPartyCommandHandler(IPoliticalPartyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<PoliticalPartyDto> Handle(UpdatePoliticalPartyCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdatePoliticalParty(request.PoliticalParty);

            if (result == null)
                throw new ErrorException("02", $"Error tratando de actualizar partido político con Id {request.PoliticalParty.Id}");

            return _mapper.Map<PoliticalPartyDto>(request.PoliticalParty);
        }
    }
    
}
