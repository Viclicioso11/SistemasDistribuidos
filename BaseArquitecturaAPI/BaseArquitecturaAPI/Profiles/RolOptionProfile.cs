﻿using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
