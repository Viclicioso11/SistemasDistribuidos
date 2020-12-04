using Application.RolActions.Dtos;
using MediatR;

namespace Application.RolActions.Querys
{
    public class GetRolByIdQuery : IRequest<RolDto>
    {
        public int Id { get; set; }
   
    }
}
