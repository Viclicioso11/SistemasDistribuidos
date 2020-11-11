using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.PoliticalPartyActions.Dtos;
using Application.PoliticalPartyActions.Querys;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PoliticalPartyActions.Handlers
{
    public class GetAllPoliticalPartiesQueryHandler : IRequestHandler<GetAllPoliticalPartiesQuery, GenericPager<PoliticalPartyDto>>
    {
        private readonly IPoliticalPartyService _service;
        private readonly IMapper _mapper;
        public GetAllPoliticalPartiesQueryHandler(IPoliticalPartyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<PoliticalPartyDto>> Handle(GetAllPoliticalPartiesQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllPoliticalParties(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;

        }
    }
    
}
