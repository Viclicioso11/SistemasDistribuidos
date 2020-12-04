using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;

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
