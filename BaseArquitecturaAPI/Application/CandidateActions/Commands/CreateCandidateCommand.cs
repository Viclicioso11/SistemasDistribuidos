using Application.CandidateActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CandidateActions.Commands
{
    public class CreateCandidateCommand : IRequest<CandidateDto>
    {
       public Candidate Candidate { get; set; }
    }
}
