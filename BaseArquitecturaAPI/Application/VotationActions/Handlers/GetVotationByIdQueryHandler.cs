using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VotationActions.Dtos;
using Application.VotationActions.Querys;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VotationActions.Handlers
{
    public class GetVotationByIdQueryHandler : IRequestHandler<GetVotationByIdQuery, VotationDto>
    {
        private readonly IVotationService _service;
        public readonly IMapper _mapper;
        public GetVotationByIdQueryHandler(IVotationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<VotationDto> Handle(GetVotationByIdQuery request, CancellationToken cancellationToken)
        {
            var votation = await _service.GetVotationById(request.VotationId);
            if (votation == null)
                throw new NotFoundException("Votación no encontrada", request.VotationId);

            return _mapper.Map<VotationDto>(votation);
        }
    }
}
