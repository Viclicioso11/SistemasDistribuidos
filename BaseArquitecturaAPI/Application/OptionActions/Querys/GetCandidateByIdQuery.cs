using Application.CandidateActions.Dtos;
using Application.OptionActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptionActions.Querys
{
    public class GetOptionByIdQuery : IRequest<OptionDto>
    {
        public int Id { get; set; }
   
    }
}
