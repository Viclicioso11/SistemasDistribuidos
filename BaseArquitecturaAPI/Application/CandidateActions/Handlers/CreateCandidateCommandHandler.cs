using Application.CandidateActions.Commands;
using Application.CandidateActions.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CandidateActions.Handlers
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, CandidateDto>
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public CreateCandidateCommandHandler(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<CandidateDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            request.Candidate.Status = true;

            var result = await _service.CreateCandidate(request.Candidate);

            if (!result)
                throw new ErrorException("01", "Error tratando de crear candidato");

            return _mapper.Map<CandidateDto>(request.Candidate);
        }
    
    }
}
