using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Profiles
{
    public class RolModelProfile : Profile
    {
        public RolModelProfile()
        {
            CreateMap<RolModelJson, Rol>();
        }
    }
}
