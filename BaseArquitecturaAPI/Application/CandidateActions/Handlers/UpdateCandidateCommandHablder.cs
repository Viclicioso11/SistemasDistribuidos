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
    public class UpdateCandidateCommandHablder : IRequestHandler<UpdateCandidateCommand, CandidateDto>
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public UpdateCandidateCommandHablder(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<CandidateDto> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateCandidate(request.Candidate);

            if (result == null)
                throw new ErrorException("02", $"Error tratando de actualizar candidato con Id {request.Candidate.Id}");

            return _mapper.Map<CandidateDto>(request.Candidate);
        }
    }
   
}
