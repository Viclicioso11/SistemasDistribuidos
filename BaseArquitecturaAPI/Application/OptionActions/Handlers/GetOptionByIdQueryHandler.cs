using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.OptionActions.Dtos;
using Application.OptionActions.Querys;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptionActions.Handlers
{
    public class GetOptionByIdQueryHandler : IRequestHandler<GetOptionByIdQuery, OptionDto>
    {
        private readonly IOptionService _service;
        private readonly IMapper _mapper;
        public GetOptionByIdQueryHandler(IOptionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<OptionDto> Handle(GetOptionByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetOptionById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return _mapper.Map<OptionDto>(result);
        }
    }
    
}
