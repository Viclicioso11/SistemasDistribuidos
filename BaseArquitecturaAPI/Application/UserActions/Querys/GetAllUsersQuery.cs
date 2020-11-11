using Application.Common.Pager;
using Application.UserActions.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Querys
{
    public class GetAllUsersQuery : IRequest<GenericPager<UserDto>>
    {
        public int ActualPage { get; set; }

        public string FilterBy { get; set; }

        public int RecordsByPage { get; set; }

    }
}
