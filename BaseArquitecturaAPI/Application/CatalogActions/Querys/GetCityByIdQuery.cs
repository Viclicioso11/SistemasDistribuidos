using Application.CatalogActions.Dtos;
using Application.Common.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CatalogActions.Querys
{
    public class GetCityByIdQuery : IRequest<CityDto>
    {
        public int Id { get; set; }
    }
}
