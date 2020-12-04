using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;

namespace BaseArquitecturaAPI.Profiles
{
    public class CandidateModelProfile : Profile
    {
        public CandidateModelProfile()
        {
            CreateMap<CandidateModelJson, Candidate>();
        }
    
    }
}
