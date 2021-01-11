using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserActions.Commands;
using Application.UserActions.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _service.ValidateUserIdentification(request.User.Identification);

            if (!userExists)
                throw new ErrorException("05", "Ya existe un usuario con la identificación presentada");

            var emailExists = await _service.ValidateUserEmail(request.User.Email);

            if (!emailExists)
                throw new ErrorException("05", "Ya existe un usuario con el correo electrónico proporcionado");
                
            var result = await _service.UpdateUser(request.User);

            if (result == null)
                throw new ErrorException("02", $"Error tratando de actualizar cliente con Id {request.User.Id}");

            return _mapper.Map<UserDto>(request.User);
        }
    }
}
