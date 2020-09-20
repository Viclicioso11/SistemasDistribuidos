using Application.Common.Mappings;
using Application.Votation.Commands;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Profiles
{
    public class VotationModelProfile : Profile
    {
        public VotationModelProfile()
        {
            CreateMap<VotationModelJson, VotationCommand>()
                .ForMember(vc => vc.CityId, v => v.MapFrom(vm => vm.CityId))
                .ForMember(vc => vc.VotationDescription, v => v.MapFrom(vm => vm.VotationDescription))
                .ForMember(vc => vc.VotationEndDate, v => v.MapFrom(vm => vm.VotationEndDate))
                .ForMember(vc => vc.VotationStartDate, v => v.MapFrom(vm => vm.VotationStartDate))
                .ForMember(vc => vc.VotationTypeId, v => v.MapFrom(vm => vm.VotationTypeId))
                .ForMember(vc => vc.VotationStatus, v => v.MapFrom(vm => vm.VotationStatus));
        }
    }
}
