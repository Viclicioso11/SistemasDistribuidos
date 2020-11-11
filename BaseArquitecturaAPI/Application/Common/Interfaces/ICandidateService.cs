using Application.CandidateActions.Dtos;
using Application.Common.Pager;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICandidateService
    {
        public Task<Candidate> GetCandidateById(int candidateId);

        public Task<Candidate> UpdateCandidate(Candidate candidate);

        public Task<bool> CreateCandidate(Candidate candidate);

        public Task<GenericPager<CandidateDto>> GetAllCandidates(string filterBy, int page, int recordsByPage);
    }
}
