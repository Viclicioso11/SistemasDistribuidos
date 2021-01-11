using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserActions.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserService _service;
        public DeleteUserCommandHandler(IUserService service)
        {
            _service = service;
            
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteUsers(request.Ids);

            if (!result)
                throw new ErrorException("03", $"Error tratando de eliminar cliente");

            return result;
        }
    }
}
