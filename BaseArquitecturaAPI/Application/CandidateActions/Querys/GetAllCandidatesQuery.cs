using Application.CandidateActions.Dtos;
using Application.Common.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CandidateActions.Querys
{
    public class GetAllCandidatesQuery : IRequest<GenericPager<CandidateDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
