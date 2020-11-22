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
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, RolDto>
    {
        private readonly IRolService _service;
        private readonly IMapper _mapper;
        public UpdateRolCommandHandler(IRolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<RolDto> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateRol(request.Rol);

            if (result == null)
                throw new ErrorException("02", $"Error tratando de actualizar rol con Id {request.Rol.Id}");

            return _mapper.Map<RolDto>(request.Rol);
        }
    }
   
}
