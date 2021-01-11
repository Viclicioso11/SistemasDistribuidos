using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;

namespace BaseArquitecturaAPI.Profiles
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<UserModelJson, User>();
        }
    }
}
