using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using AutoMapper;

namespace Application.Test.Dtos
{
    public class TestDto : IMapFrom<TestEntity>
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TestEntity, TestDto>()
                .ForMember(td => td.Id, t => t.MapFrom(te => te.IdTest))
                .ForMember(td => td.Name, t => t.MapFrom(te => te.Name))
                .ForMember(td => td.Description, t => t.MapFrom(te => te.Description));
        }


    }
}

