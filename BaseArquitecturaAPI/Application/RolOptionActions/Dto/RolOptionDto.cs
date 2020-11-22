using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolOptionActions.Dtos
{
    public class RolOptionDto : IMapFrom<RolOption>
    {
        public int Id { get; set; }

        public string Rolname { get; set; }

        public string OptionName { get; set; }

        public int RolId { get; set; }

        public int OptionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RolOption, RolOptionDto>();
        }
    }
}
