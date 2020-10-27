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
        public int UserId { get; set; }

        public string Identification { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
        }

    }
}
