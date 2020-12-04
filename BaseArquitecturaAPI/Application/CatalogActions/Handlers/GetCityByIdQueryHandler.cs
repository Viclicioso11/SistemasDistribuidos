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
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly ICatalogService _service;
        private readonly IMapper _mapper;
        public GetCityByIdQueryHandler(ICatalogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetCityById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return result;
        }
    }
}
