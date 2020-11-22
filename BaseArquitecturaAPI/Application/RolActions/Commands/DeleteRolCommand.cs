using Application.CandidateActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Commands
{
    public class DeleteRolCommand : IRequest<bool>
    {
        public List<int> Ids { get; set; }
    }
}
