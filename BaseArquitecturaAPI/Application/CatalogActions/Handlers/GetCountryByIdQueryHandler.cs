using Application.CatalogActions.Dtos;
using Application.CatalogActions.Querys;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryDto>
    {
        private readonly ICatalogService _service;
        private readonly IMapper _mapper;
        public GetCountryByIdQueryHandler(ICatalogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetCountryById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return result;
        }
    }
}
