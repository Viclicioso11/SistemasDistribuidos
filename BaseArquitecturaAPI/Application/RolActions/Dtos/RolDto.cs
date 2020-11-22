using Application.Common.Mappings;
using Application.OptionActions.Dtos;
using Application.RolOptionActions.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RolActions.Dtos
{
    public class RolDto : IMapFrom<Rol>
    {
        public int Id { get; set; }

        public string RolName { get; set; }

        public List<OptionDto> RolOptions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rol, RolDto>();
        }
    }
}
