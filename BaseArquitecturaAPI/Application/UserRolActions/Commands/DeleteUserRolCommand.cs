using Application.CandidateActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserRolActions.Commands
{
    public class DeleteUserRolCommand : IRequest<bool>
    {
        public int UserId  { get; set; }

        public int RolId { get; set; }

    }
}
