using Application.OptionActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptionActions.Commands
{
    public class UpdateOptionCommand : IRequest<OptionDto>
    {
        public Option Option { get; set; }

    }
}
