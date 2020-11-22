using Application.CandidateActions.Dtos;
using Application.OptionActions.Dtos;
using Application.RolActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Querys
{
    public class GetRolByIdQuery : IRequest<RolDto>
    {
        public int Id { get; set; }
   
    }
}
