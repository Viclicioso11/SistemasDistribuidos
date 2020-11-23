using Application.CandidateActions.Dtos;
using Application.RolOptionActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolOptionActions.Commands
{
    public class CreateRolOptionCommand : IRequest<bool>
    {
        public int IdRol { get; set; }

        public List<int> OptionIds { get; set; }
    }
}
