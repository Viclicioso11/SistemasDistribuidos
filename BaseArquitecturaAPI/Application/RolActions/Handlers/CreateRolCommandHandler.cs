using Application.CandidateActions.Commands;
using Application.CandidateActions.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.OptionActions.Commands;
using Application.OptionActions.Dtos;
using Application.RolActions.Commands;
using Application.RolActions.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RolActions.Handlers
{
    public class CreateOptionCommandHandler : IRequestHandler<CreateRolCommand, RolDto>
    {
        private readonly IRolService _service;
        private readonly IMapper _mapper;
        public CreateOptionCommandHandler(IRolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<RolDto> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateRol(request.Rol);

            if (!result)
                throw new ErrorException("01", "Error tratando de crear Rol");

            return _mapper.Map<RolDto>(request.Rol);
        }
    
    }
}
