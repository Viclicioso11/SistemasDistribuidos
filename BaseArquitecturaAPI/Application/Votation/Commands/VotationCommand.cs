using Application.Votation.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Votation.Commands
{
    public class VotationCommand : IRequest<VotationDto>
    {
        public int VotationId { get; set; }

        public int VotationTypeId { get; set; }

        public string VotationDescription { get; set; }

        public DateTime VotationStartDate { get; set; }

        public DateTime VotationEndDate { get; set; }

        public bool VotationStatus { get; set; }

        public int CityId { get; set; }


    }
}
