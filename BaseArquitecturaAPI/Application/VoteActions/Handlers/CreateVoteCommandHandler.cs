using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VoteActions.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VoteActions.Handlers
{
    public class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommand, bool>
    {
        private readonly IVoteService _service;
        private readonly IUserRolService _userRolService;
        private readonly IMapper _mapper;
        public CreateVoteCommandHandler(IVoteService service, IMapper mapper, IUserRolService userRolService)
        {
            _service = service;
            _userRolService = userRolService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
        {
            var isVotationValid = await _service.IsValidVotation(request.Vote.VotationId);

            if (!isVotationValid)
                throw new ErrorException("99", "La votación no ya está activa o no existe");

            var hasUserVoted = await _service.UserHasAlreadyVoted(request.Vote.UserId, request.Vote.VotationId);

            // validar que el rol del usuario no es admin

            var userRol = await _userRolService.GetRolByUserId(request.Vote.UserId);

            if (userRol.Id != 2)
                throw new ErrorException("102", "Usuarios con este rol no pueden votar");


            if (hasUserVoted)
                throw new ErrorException("100", "Este usuario ya votó");

            var isValidCandidate = await _service.CandidateIsInVotation(request.Vote.CandidateId, request.Vote.VotationId);

            if (!isValidCandidate)
                throw new ErrorException("101", "Este candidato no pertenece a esta votación");

            var result = await _service.CreateVote(request.Vote);

            if (!result)
                throw new ErrorException("01", "No se ha podido realizar el voto");

            return true;
        }
    
    }
}
