using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserRolActions.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserRolActions.Handlers
{
    public class CreateUserRolCommandHandler : IRequestHandler<CreateUserRolCommand, bool>
    {
        private readonly IUserRolService _service;
        private readonly IMapper _mapper;
        public CreateUserRolCommandHandler(IUserRolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateUserRolCommand request, CancellationToken cancellationToken)
        {

            var result = await _service.CreateUserRol(request.IdUser, request.RolIds);

            if (!result)
                throw new ErrorException("01", "Error tratando de crear roles para un usuario");

            return true;
        }
    
    }
}
