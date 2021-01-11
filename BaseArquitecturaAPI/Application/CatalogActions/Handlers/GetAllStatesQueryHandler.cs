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
    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, GenericPager<StateDto>>
    {
        private readonly ICatalogService _service;
        private readonly IMapper _mapper;
        public GetAllStatesQueryHandler(ICatalogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<StateDto>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllStates(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;
            
        }
    }
}
