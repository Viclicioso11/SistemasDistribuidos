using Application.CatalogActions.Dtos;
using Application.CatalogActions.Querys;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.UserActions.Dtos;
using Application.UserActions.Querys;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
