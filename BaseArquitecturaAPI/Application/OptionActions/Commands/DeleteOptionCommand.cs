using Application.CandidateActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptionActions.Commands
{
    public class DeleteOptionCommand : IRequest<bool>
    {
        public List<int> Ids { get; set; }
    }
}
