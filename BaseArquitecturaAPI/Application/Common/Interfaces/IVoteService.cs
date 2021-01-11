using Application.VoteActions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IVoteService
    {
        Task<bool> CreateVote(Vote vote);

        Task<bool> UserHasAlreadyVoted(int userId, int votationId);

        Task<bool> IsValidVotation(int votationId);

        Task<bool> CandidateIsInVotation(int candidateId, int votationId);

        Task<List<VoteCount>> CountVotes(int votationId);

    }
}
