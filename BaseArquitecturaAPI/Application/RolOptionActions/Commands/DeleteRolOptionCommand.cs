using Application.CandidateActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolOptionActions.Commands
{
    public class DeleteRolOptionCommand : IRequest<bool>
    {
        public List<RolOption> rolOptions { get; set; }

    }
}
