using Application.OptionActions.Dtos;
using MediatR;

namespace Application.OptionActions.Querys
{
    public class GetOptionByIdQuery : IRequest<OptionDto>
    {
        public int Id { get; set; }
   
    }
}
