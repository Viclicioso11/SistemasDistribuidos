using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;

namespace BaseArquitecturaAPI.Profiles
{
    public class OptionModelProfile : Profile
    {
        public OptionModelProfile()
        {
            CreateMap<OptionModelJson, Option>();
        }
    }
}
