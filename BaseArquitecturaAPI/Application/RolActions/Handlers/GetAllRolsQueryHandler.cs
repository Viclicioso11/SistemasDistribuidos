using Application.CandidateActions.Dtos;
using Application.CandidateActions.Querys;
using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.OptionActions.Dtos;
using Application.OptionActions.Querys;
using Application.RolActions.Dtos;
using Application.RolActions.Querys;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RolActions.Handlers
{
    public class GetAllOptionsQueryHandler : IRequestHandler<GetAllRolsQuery, GenericPager<RolDto>>
    {
        private readonly IRolService _service;
        private readonly IMapper _mapper;
        public GetAllOptionsQueryHandler(IRolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<RolDto>> Handle(GetAllRolsQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllRols(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;

        }
    }
}
