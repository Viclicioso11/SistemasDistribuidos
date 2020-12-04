using Application.CatalogActions.Dtos;
using Application.Common.Pager;
using MediatR;

namespace Application.CatalogActions.Querys
{
    public class GetAllStatesQuery : IRequest<GenericPager<StateDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
