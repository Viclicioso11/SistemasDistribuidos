using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RolOptionActions.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RolOptionActions.Handlers
{
    public class DeleteRolOptionCommandHandler : IRequestHandler<DeleteRolOptionCommand, bool>
    {
        private readonly IRolOptionService _service;
        private readonly IMapper _mapper;
        public DeleteRolOptionCommandHandler(IRolOptionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteRolOptionCommand request, CancellationToken cancellationToken)
        {

            var result = await _service.DeleteRolOption(request.rolOptions);

            if (!result)
                throw new ErrorException("01", "Error tratando de eliminar las opciones de un rol");

            return true;
        }
    
    }
}
