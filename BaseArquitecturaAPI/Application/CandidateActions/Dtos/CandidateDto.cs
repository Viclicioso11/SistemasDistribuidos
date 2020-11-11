using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CandidateActions.Dtos
{
    public class CandidateDto : IMapFrom<Candidate>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public string PoliticalPartyName { get; set; }

        public int PoliticalPartyId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Candidate, CandidateDto>();
        }
    }
}
