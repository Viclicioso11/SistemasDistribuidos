using Application.CatalogActions.Dtos;
using MediatR;

namespace Application.CatalogActions.Querys
{
    public class GetCityByIdQuery : IRequest<CityDto>
    {
        public int Id { get; set; }
    }
}
