using Application.Common.Mappings;
using AutoMapper;
using votation = Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Votation.Dtos
{
    public class VotationDto : IMapFrom<votation.Votation>
    {
        //TO DO
        public void Mapping(Profile profile)
        {
            
        }
    }
}
