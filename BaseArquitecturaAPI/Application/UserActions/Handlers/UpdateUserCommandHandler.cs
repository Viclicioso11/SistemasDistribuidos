using Application.Common.Exceptions;
using Application.Common.Interfaces;
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
            var result = await _service.UpdateUser(request.User);

            if (result == null)
                throw new ErrorException("02", $"Error tratando de actualizar cliente con Id {request.User.Id}");

            return _mapper.Map<UserDto>(request.User);
        }
    }
}
