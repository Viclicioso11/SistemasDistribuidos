using Application.CatalogActions.Dtos;
using Application.Common.Pager;
using MediatR;

namespace Application.CatalogActions.Querys
{
    public class GetAllCountriesQuery : IRequest<GenericPager<CountryDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
