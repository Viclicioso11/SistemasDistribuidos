using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VotationActions.Dtos
{
    public class VotationDto : IMapFrom<Votation>
    {
        public int VotationId { get; set; }

        public int VotationTypeId { get; set; }

        public string VotationDescription { get; set; }

        public DateTime VotationStartDate { get; set; }

        public DateTime VotationEndDate { get; set; }

        public bool VotationStatus { get; set; }

        public City City { get; set; }

        public VotationType VotationType { get; set; }

        public void Mapping(Profile profile)
        {   
            profile.CreateMap<Votation, VotationDto>()
                .ForMember(vt => vt.VotationId, opt => opt.MapFrom(v => v.VotationId))
                .ForMember(vt => vt.VotationDescription, opt => opt.MapFrom(v => v.VotationDescription))
                .ForMember(vt => vt.VotationEndDate, opt => opt.MapFrom(v => v.VotationEndDate))
                .ForMember(vt => vt.VotationStartDate, opt => opt.MapFrom(v => v.VotationStartDate))
                .ForMember(vt => vt.VotationTypeId, opt => opt.MapFrom(v => v.VotationTypeId))
                .ForMember(vt => vt.VotationStatus, opt => opt.MapFrom(v => v.VotationStatus));

        }
    }
}
