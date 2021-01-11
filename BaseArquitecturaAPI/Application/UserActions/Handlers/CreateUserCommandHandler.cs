using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserActions.Commands;
using Application.UserActions.Dtos;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
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
            var userExists = await _service.ValidateUserIdentification(request.User.Identification);

            if (!userExists)
                throw new ErrorException("05", "Ya existe un usuario con la identificación presentada");

            var emailExists = await _service.ValidateUserEmail(request.User.Email);

            if (!emailExists)
                throw new ErrorException("05", "Ya existe un usuario con el correo electrónico proporcionado");

            request.User.Status = true;

            var userId = await _service.CreateUser(request.User);

            if (userId == 0)
                throw new ErrorException("01", "Error tratando de crear cliente");

            // si no mandan el rol id, por defecto se le dara el de admin
            if (request.RolId == 0)
                request.RolId = 1;

            var asigned = await _userRolService.CreateUserRol(userId, new List<int> { request.RolId });

            if (!asigned)
                throw new ErrorException("01", "Error tratando de asignar rol a usuario");

            return  _mapper.Map<UserDto>(request.User);
        }
    }
}
