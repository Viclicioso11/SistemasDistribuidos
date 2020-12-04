using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;

namespace BaseArquitecturaAPI.Profiles
{
    public class VoteModelProfile : Profile
    {
        public VoteModelProfile()
        {
            CreateMap<VoteModelJson, Vote>();
                
        }
    }
}
