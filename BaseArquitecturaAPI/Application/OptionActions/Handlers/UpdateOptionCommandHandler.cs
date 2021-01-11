using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.OptionActions.Commands;
using Application.OptionActions.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptionActions.Handlers
{
    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand, OptionDto>
    {
        private readonly IOptionService _service;
        private readonly IMapper _mapper;
        public UpdateOptionCommandHandler(IOptionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<OptionDto> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateOption(request.Option);

            if (result == null)
                throw new ErrorException("02", $"Error tratando de actualizar opción con Id {request.Option.Id}");

            return _mapper.Map<OptionDto>(request.Option);
        }
    }
   
}
