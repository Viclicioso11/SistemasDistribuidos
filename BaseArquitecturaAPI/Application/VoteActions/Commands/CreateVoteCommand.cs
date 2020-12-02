using Application.OptionActions.Dtos;
using Application.RolActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VoteActions.Commands
{
    public class CreateVoteCommand : IRequest<bool>
    {
        public Vote Vote { get; set; }
    }
}
