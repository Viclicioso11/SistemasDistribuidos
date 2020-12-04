using Application.Common.Pager;
using Application.PoliticalPartyActions.Dtos;
using MediatR;

namespace Application.PoliticalPartyActions.Querys
{
    public class GetAllPoliticalPartiesQuery : IRequest<GenericPager<PoliticalPartyDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
    
}
