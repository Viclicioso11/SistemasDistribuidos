using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RolOptionActions.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CandidateActions.Handlers
{
    public class CreateRolOptionCommandHandler : IRequestHandler<CreateRolOptionCommand, bool>
    {
        private readonly IRolOptionService _service;
        private readonly IMapper _mapper;
        public CreateRolOptionCommandHandler(IRolOptionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateRolOptionCommand request, CancellationToken cancellationToken)
        {

            var result = await _service.CreateRolOption(request.IdRol, request.OptionIds);

            if (!result)
                throw new ErrorException("01", "Error tratando de crear opciones de un rol");

            return true;
        }
    
    }
}
