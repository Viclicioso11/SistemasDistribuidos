using Application.CatalogActions.Dtos;
using MediatR;

namespace Application.CatalogActions.Querys
{
    public class GetStateByIdQuery : IRequest<StateDto>
    {
        public int Id { get; set; }
    }
}
