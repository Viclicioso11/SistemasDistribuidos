using Application.Common.Pager;
using Application.RolActions.Dtos;
using MediatR;

namespace Application.RolActions.Querys
{
    public class GetAllRolsQuery : IRequest<GenericPager<RolDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
