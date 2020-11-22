using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptionActions.Dtos
{
    public class OptionDto : IMapFrom<Option>
    {
        public int Id { get; set; }

        public string OptionName { get; set; }

        public string OptionDescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Option, OptionDto>();
        }
    }
}
