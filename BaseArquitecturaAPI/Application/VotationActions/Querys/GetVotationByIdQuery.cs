using Application.VotationActions.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VotationActions.Querys
{
    public class GetVotationByIdQuery : IRequest<VotationDto>
    {
        public int VotationId { get; set; }
    }
}
