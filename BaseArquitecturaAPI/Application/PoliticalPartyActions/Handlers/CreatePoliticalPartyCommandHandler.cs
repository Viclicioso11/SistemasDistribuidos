using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.PoliticalPartyActions.Commands;
using Application.PoliticalPartyActions.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PoliticalPartyActions.Handlers
{
    public class CreatePoliticalPartyCommandHandler : IRequestHandler<CreatePoliticalPartyCommand, PoliticalPartyDto>
    {
        private readonly IPoliticalPartyService _service;
        private readonly IMapper _mapper;
        public CreatePoliticalPartyCommandHandler(IPoliticalPartyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<PoliticalPartyDto> Handle(CreatePoliticalPartyCommand request, CancellationToken cancellationToken)
        {
            
            var result = await _service.CreatePoliticalParty(request.PoliticalParty);

            if (!result)
                throw new ErrorException("01", "Error tratando de crear partido político");

            return _mapper.Map<PoliticalPartyDto>(request.PoliticalParty);
        }

    }
    
}
