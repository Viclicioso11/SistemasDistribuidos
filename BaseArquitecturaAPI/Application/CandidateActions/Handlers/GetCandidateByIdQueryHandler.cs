using Application.CandidateActions.Dtos;
using Application.CandidateActions.Querys;
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
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public GetCandidateByIdQueryHandler(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<CandidateDto> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetCandidateById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return _mapper.Map<CandidateDto>(result);
        }
    }
    
}
