using Application.Common.Mappings;
using Application.OptionActions.Dtos;
using Application.RolOptionActions.Dtos;
using Application.VotationActions.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VoteActions.Dtos
{
    public class VoteDto : IMapFrom<Votation>
    {
        public int VotationId { get; set; }

        public int VotationTypeId { get; set; }

        public string VotationTypeName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string VotationDescription { get; set; }

        public DateTime VotationStartDate { get; set; }

        public DateTime VotationEndDate { get; set; }

        public bool VotationStatus { get; set; }

        public List<VoteCount> VotesCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VotationDto, VoteDto>()
                .ForMember(vt => vt.VotationId, opt => opt.MapFrom(v => v.Id));
        }
    }

    public class VoteCount
    {
        public string CandidateName { get; set; }

        public int CandidateId { get; set; }

        public int TotalVotes { get; set; }

        public string PoliticalPartyName { get; set; }

        public int PoliticalPartyId { get; set; }
    }
}
