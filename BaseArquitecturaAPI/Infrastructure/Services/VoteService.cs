using Application.Common.Interfaces;
using Application.VoteActions.Dtos;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class VoteService : IVoteService
    {
        private readonly DatabaseContext _context;
        public VoteService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateVote(Vote vote)
        {
            _context.Votes.Add(vote);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<bool> UserHasAlreadyVoted(int userId, int votationId)
        {
            var alreadyVoted = await _context.Votes.Where(v => v.UserId == userId && v.VotationId == votationId).ToListAsync();

            if (alreadyVoted.Count > 0)
                return true;

            return false;
        }

        public async Task<bool> CandidateIsInVotation(int candidateId, int votationId)
        {
            var isCandidateValid = await _context.VotationDetail.Where(vt => vt.CandidateId == candidateId && vt.VotationId == votationId).FirstOrDefaultAsync();

            if (isCandidateValid != null)
                return true;

            return false;
        }

        public async Task<bool> IsValidVotation(int votationId)
        {
            var votation = await _context.Votations.FindAsync(votationId);

            if (votation == null)
                return false;

            if (DateTime.Now < votation.VotationStartDate || DateTime.Now > votation.VotationEndDate)
                return false;

            if (!votation.VotationStatus)
                return false;

            return true;
        }

        public async Task<List<VoteCount>> CountVotes(int votationId)
        {
            var votesInfo = await _context.Votes.Where(v => v.VotationId == votationId).ToListAsync();

            if (votesInfo == null)
                return null;

            var candidatesId = votesInfo.Select(v => v.CandidateId).Distinct().ToList();

            var voteCountInfo = new List<VoteCount>();

            foreach (var candidateId in candidatesId)
            {
                var candidateInfo = (from c in _context.Candidates
                                    join p in _context.PoliticalParties
                                    on c.PoliticalPartyId equals p.Id
                                    where c.Id == candidateId
                                    select new VoteCount
                                    {
                                        CandidateId = c.Id,
                                        CandidateName = $"{c.FirstName} {c.MiddleName} {c.LastName} {c.Surname}",
                                        PoliticalPartyId = c.PoliticalPartyId,
                                        PoliticalPartyName = p.PoliticalPartyName
                                    }).FirstOrDefault();

                candidateInfo.TotalVotes = votesInfo.Where(v => v.CandidateId == candidateId).Count();

                voteCountInfo.Add(candidateInfo);
            }

            return voteCountInfo;

        }
    }
}
