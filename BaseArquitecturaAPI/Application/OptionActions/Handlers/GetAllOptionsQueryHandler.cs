using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.OptionActions.Dtos;
using Application.OptionActions.Querys;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptionActions.Handlers
{
    public class GetAllOptionsQueryHandler : IRequestHandler<GetAllOptionsQuery, GenericPager<OptionDto>>
    {
        private readonly IOptionService _service;
        private readonly IMapper _mapper;
        public GetAllOptionsQueryHandler(IOptionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<OptionDto>> Handle(GetAllOptionsQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllOptions(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;

        }
    }
}
