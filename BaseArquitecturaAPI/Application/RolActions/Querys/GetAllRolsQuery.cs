using Application.CandidateActions.Dtos;
using Application.Common.Pager;
using Application.OptionActions.Dtos;
using Application.RolActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Querys
{
    public class GetAllRolsQuery : IRequest<GenericPager<RolDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }
    }
}
