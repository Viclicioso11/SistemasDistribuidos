using Application.UserActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Querys
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
