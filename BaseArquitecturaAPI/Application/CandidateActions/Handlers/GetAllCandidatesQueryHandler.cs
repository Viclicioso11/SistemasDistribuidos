using Application.CandidateActions.Dtos;
using Application.CandidateActions.Querys;
using Application.Common.Interfaces;
using Application.Common.Pager;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CandidateActions.Handlers
{
    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, GenericPager<CandidateDto>>
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public GetAllCandidatesQueryHandler(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllCandidates(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;

        }
    }
}
