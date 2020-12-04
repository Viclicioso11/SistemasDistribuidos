using Application.CatalogActions.Dtos;
using Application.CatalogActions.Querys;
using Application.Common.Interfaces;
using Application.Common.Pager;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CatalogActions.Handlers
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, GenericPager<CityDto>>
    {
        private readonly ICatalogService _service;
        private readonly IMapper _mapper;
        public GetAllCitiesQueryHandler(ICatalogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<CityDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllCities(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;
            
        }
    }
}
