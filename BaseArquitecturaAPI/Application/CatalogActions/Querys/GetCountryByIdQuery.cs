using Application.CatalogActions.Dtos;
using MediatR;

namespace Application.CatalogActions.Querys
{
    public class GetCountryByIdQuery : IRequest<CountryDto>
    {
        public int Id { get; set; }
    }
}
