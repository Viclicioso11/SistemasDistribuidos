using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.UserActions.Commands;
using Application.UserActions.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserService _service;
        private readonly IUserRolService _userRolService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService service, IMapper mapper, IUserRolService userRolService)
        {
            _service = service;
            _mapper = mapper;
            _userRolService = userRolService;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.Status = true;

            var userId = await _service.CreateUser(request.User);

            if (userId == 0)
                throw new ErrorException("01", "Error tratando de crear cliente");

            var asigned = await _userRolService.CreateUserRol(userId, new List<int> { request.RolId });

            if (!asigned)
                throw new ErrorException("01", "Error tratando de asignar rol a usuario");

            return  _mapper.Map<UserDto>(request.User);
        }
    }
}
