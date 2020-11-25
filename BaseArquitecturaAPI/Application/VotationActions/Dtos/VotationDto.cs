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
        public int Id { get; set; }

        public int VotationTypeId { get; set; }

        public string VotationTypeName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string VotationDescription { get; set; }

        public DateTime VotationStartDate { get; set; }

        public DateTime VotationEndDate { get; set; }

        public bool VotationStatus { get; set; }

        public void Mapping(Profile profile)
        {   
            profile.CreateMap<Votation, VotationDto>()
                .ForMember(vt => vt.Id, opt => opt.MapFrom(v => v.Id))
                .ForMember(vt => vt.VotationDescription, opt => opt.MapFrom(v => v.VotationDescription))
                .ForMember(vt => vt.VotationEndDate, opt => opt.MapFrom(v => v.VotationEndDate))
                .ForMember(vt => vt.VotationStartDate, opt => opt.MapFrom(v => v.VotationStartDate))
                .ForMember(vt => vt.VotationTypeId, opt => opt.MapFrom(v => v.VotationTypeId))
                .ForMember(vt => vt.VotationStatus, opt => opt.MapFrom(v => v.VotationStatus));

        }
    }
}
