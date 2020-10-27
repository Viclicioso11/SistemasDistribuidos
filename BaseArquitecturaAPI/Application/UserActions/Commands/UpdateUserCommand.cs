﻿using Application.UserActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public User User { get; set; } 
    }
}