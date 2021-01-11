﻿using Application.OptionActions.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.OptionActions.Commands
{
    public class UpdateOptionCommand : IRequest<OptionDto>
    {
        public Option Option { get; set; }

    }
}
