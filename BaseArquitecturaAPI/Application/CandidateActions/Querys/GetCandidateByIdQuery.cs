using Application.CandidateActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CandidateActions.Querys
{
    public class GetCandidateByIdQuery : IRequest<CandidateDto>
    {
        public int Id { get; set; }
   
    }
}
