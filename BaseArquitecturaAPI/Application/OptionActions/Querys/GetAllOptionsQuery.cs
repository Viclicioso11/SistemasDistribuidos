using Application.CandidateActions.Dtos;
using Application.Common.Pager;
using Application.OptionActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptionActions.Querys
{
    public class GetAllOptionsQuery : IRequest<GenericPager<OptionDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
