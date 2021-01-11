using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.PoliticalPartyActions.Dtos;
using Application.PoliticalPartyActions.Querys;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PoliticalPartyActions.Handlers
{
    public class GetPoliticalPartyByIdQueryHandler : IRequestHandler<GetPoliticalPartyByIdQuery, PoliticalPartyDto>
    {
        private readonly IPoliticalPartyService _service;
        private readonly IMapper _mapper;
        public GetPoliticalPartyByIdQueryHandler(IPoliticalPartyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<PoliticalPartyDto> Handle(GetPoliticalPartyByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetPoliticalPartyById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return _mapper.Map<PoliticalPartyDto>(result);
        }
    }
    
}
