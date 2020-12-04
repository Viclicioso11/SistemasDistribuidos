using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using System.Collections.Generic;

namespace BaseArquitecturaAPI.Profiles
{
    public class RolOptionProfile : Profile
    {
        public RolOptionProfile()
        {
            CreateMap<RolOptionModelJson, RolOption>()
                .ForMember(r => r.RolId, opt => opt.MapFrom(v => v.RolId))
                .ForMember(r => r.OptionId, opt => opt.MapFrom(v => v.OptionId));

            CreateMap<List<RolOptionModelJson>, List<RolOption>>();

        }
    }
}
