using Application.CandidateActions.Dtos;
using Application.Common.Interfaces;
using Application.Common.Pager;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly DatabaseContext _context;
        public CandidateService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCandidate(Candidate candidate)
        {
            _context.Add(candidate);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<GenericPager<CandidateDto>> GetAllCandidates(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<CandidateDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;


            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await
                    (
                    from c in _context.Candidates
                    join p in _context.PoliticalParties
                    on c.PoliticalPartyId equals p.Id
                    where c.Status == true
                    select new CandidateDto
                    {
                        FirstName = c.FirstName,
                        Surname = c.Surname,
                        LastName = c.LastName,
                        MiddleName = c.MiddleName,
                        PoliticalPartyId = c.PoliticalPartyId,
                        PoliticalPartyName = p.PoliticalPartyName,
                        Id = c.Id,
                        Status = c.Status
                    })
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .ToListAsync();

                information.TotalRecords = _context.Candidates.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {

                information.Results = await
                    (
                    from c in _context.Candidates
                    join p in _context.PoliticalParties
                    on c.PoliticalPartyId equals p.Id
                    where c.FirstName.Contains(filterBy) || c.LastName.Contains(filterBy) 
                    || c.MiddleName.Contains(filterBy) || c.Surname.Contains(filterBy) && c.Status == true
                    select new CandidateDto
                    {
                        FirstName = c.FirstName,
                        Surname = c.Surname,
                        LastName = c.LastName,
                        MiddleName = c.MiddleName,
                        PoliticalPartyId = c.PoliticalPartyId,
                        PoliticalPartyName = p.PoliticalPartyName,
                        Id = c.Id,
                        Status = c.Status
                    })
                    .ToListAsync();


                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }

            return information;
        }

        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            var candidate = await _context.Candidates.Where(u => u.Status == true && u.Id == candidateId).FirstOrDefaultAsync();

            if (candidate != null)
                return candidate;

            return null;
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            var candidateToEdit = _context.Candidates.Find(candidate.Id);

            candidateToEdit.FirstName = candidate.FirstName;
            candidateToEdit.LastName = candidate.LastName;
            candidateToEdit.MiddleName = candidate.MiddleName;
            candidateToEdit.Surname = candidate.Surname;

            _context.Candidates.Update(candidateToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return candidate;

            return null;
        }
    }
}
