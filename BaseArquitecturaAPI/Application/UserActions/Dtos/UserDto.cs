using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Dtos
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }

        public string Identification { get; set; }

        public string Names { get; set; }

        public string LastNames { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
        }

    }
}
