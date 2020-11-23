using Application.CandidateActions.Dtos;
using Application.RolOptionActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserRolActions.Commands
{
    public class CreateUserRolCommand : IRequest<bool>
    {
        public int IdUser { get; set; }

        public List<int> RolIds { get; set; }
    }
}
