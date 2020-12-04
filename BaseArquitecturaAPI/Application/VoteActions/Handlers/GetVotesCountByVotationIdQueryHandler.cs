using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VoteActions.Dtos;
using Application.VoteActions.Querys;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VoteActions.Handlers
{
    public class GetVotesCountByVotationIdQueryHandler : IRequestHandler<GetVotesCountByVotationIdQuery, VoteDto>
    {
        private readonly IVoteService _service;
        private readonly IVotationService _votationService;
        private readonly IMapper _mapper;
        public GetVotesCountByVotationIdQueryHandler(IVoteService service, IVotationService votationService, IMapper mapper)
        {
            _service = service;
            _votationService = votationService;
            _mapper = mapper;
        }
        public async Task<VoteDto> Handle(GetVotesCountByVotationIdQuery request, CancellationToken cancellationToken)
        {
            var votation = await _votationService.GetVotationById(request.VotationId);

            if (votation == null)
                throw new ErrorException("05", "La votación solicitada no existe");

            var voteCountInfo = _mapper.Map<VoteDto>(votation);

            var candidateVoteInfo = await _service.CountVotes(request.VotationId);


            if (candidateVoteInfo == null || candidateVoteInfo.Count == 0)
                throw new ErrorException("06", "No se realizaron votos");

            voteCountInfo.VotesCount = candidateVoteInfo;

            return voteCountInfo;
        }
    }
}
