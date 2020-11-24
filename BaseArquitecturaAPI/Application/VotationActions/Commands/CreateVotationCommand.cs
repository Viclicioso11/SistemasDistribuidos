using Application.VotationActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VotationActions.Commands
{
    public class CreateVotationCommand : IRequest<bool>
    {
        public Votation Votation { get; set; }
    }
}
