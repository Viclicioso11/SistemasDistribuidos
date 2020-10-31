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
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, GenericPager<CountryDto>>
    {
        private readonly ICatalogService _service;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(ICatalogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllCountries(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;
            
        }
    }
}
