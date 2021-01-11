using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserRolActions.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserRolActions.Handlers
{
    public class DeleteUserRolCommandHandler : IRequestHandler<DeleteUserRolCommand, bool>
    {
        private readonly IUserRolService _service;
        private readonly IMapper _mapper;
        public DeleteUserRolCommandHandler(IUserRolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteUserRolCommand request, CancellationToken cancellationToken)
        {

            var result = await _service.DeleteUserRol(request.UserId, request.RolId);

            if (!result)
                throw new ErrorException("01", "Error tratando de eliminar las rol de un usuario");

            return true;
        }
    
    }
}
