using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;

namespace BaseArquitecturaAPI.Profiles
{
    public class PoliticalPartyModelProfile : Profile
    {
        public PoliticalPartyModelProfile()
        {
            CreateMap<PoliticalPartyModelJson, PoliticalParty>();
        }

    } 
    
}
