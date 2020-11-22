using Application.CandidateActions.Dtos;
using Application.CandidateActions.Querys;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
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
    public class GetOptionByIdQueryHandler : IRequestHandler<GetRolByIdQuery, RolDto>
    {
        private readonly IRolService _service;
        private readonly IMapper _mapper;
        public GetOptionByIdQueryHandler(IRolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<RolDto> Handle(GetRolByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetRolById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return _mapper.Map<RolDto>(result);
        }
    }
    
}
