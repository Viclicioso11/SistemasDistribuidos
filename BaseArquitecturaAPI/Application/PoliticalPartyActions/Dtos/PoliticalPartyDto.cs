using Application.CandidateActions.Dtos;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.PoliticalPartyActions.Dtos
{
    public class PoliticalPartyDto : IMapFrom<PoliticalParty>
    {
        public int Id { get; set; }

        public string PoliticalPartyName { get; set; }

        public string Abreviation { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CandidateDto> Candidates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PoliticalParty, PoliticalPartyDto>();
        }
    }
}
