using Application.Common.Pager;
using Application.VotationActions.Dtos;
using MediatR;

namespace Application.VotationActions.Querys
{
    public class GetAllVotationsQuery : IRequest<GenericPager<VotationDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
