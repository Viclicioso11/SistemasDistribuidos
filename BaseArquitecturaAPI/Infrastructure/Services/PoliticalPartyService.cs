using Application.CandidateActions.Dtos;
using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.PoliticalPartyActions.Dtos;
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
    public class PoliticalPartyService : IPoliticalPartyService
    {
        private readonly DatabaseContext _context;
        public PoliticalPartyService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePoliticalParty(PoliticalParty politicalPaty)
        {
            _context.Add(politicalPaty);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<GenericPager<PoliticalPartyDto>> GetAllPoliticalParties(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<PoliticalPartyDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;


            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await _context.PoliticalParties
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Select(p => new PoliticalPartyDto
                    {
                        Abreviation = p.Abreviation,
                        Id = p.Id,
                        PoliticalPartyName = p.PoliticalPartyName
                    })
                    .ToListAsync();

                information.TotalRecords = _context.PoliticalParties.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {

                information.Results = await _context.PoliticalParties
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Where(u => u.Abreviation.Contains(filterBy) ||
                            u.PoliticalPartyName.Contains(filterBy))
                    .Select(p => new PoliticalPartyDto
                    {
                        Abreviation = p.Abreviation,
                        Id = p.Id,
                        PoliticalPartyName = p.PoliticalPartyName
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

        public async Task<PoliticalPartyDto> GetPoliticalPartyById(int politicalPatyId)
        {
            var politicalParty = await(from p in _context.PoliticalParties
                                where p.Id == politicalPatyId
                                select new PoliticalPartyDto
                                {
                                    Abreviation = p.Abreviation,
                                    PoliticalPartyName = p.PoliticalPartyName,
                                    Id = p.Id

                                }).FirstOrDefaultAsync();

            if (politicalParty != null)
            {
                politicalParty.Candidates = from c in _context.Candidates 
                                            where c.Status == true && c.PoliticalPartyId == politicalPatyId
                                 select new CandidateDto
                                 {
                                     FirstName = c.FirstName,
                                     LastName = c.LastName,
                                     MiddleName = c.MiddleName,
                                     Surname = c.Surname,
                                     Id = c.Id,
                                     PoliticalPartyId = c.PoliticalPartyId,
                                     PoliticalPartyName = politicalParty.PoliticalPartyName
                                 };

                return politicalParty;
            }

            return null;
        }

        public async Task<PoliticalParty> UpdatePoliticalParty(PoliticalParty politicalParty)
        {
            var politicalPartyToEdit = _context.PoliticalParties.Find(politicalParty.Id);

            politicalPartyToEdit.Abreviation = politicalParty.Abreviation;
            politicalPartyToEdit.PoliticalPartyName = politicalParty.PoliticalPartyName;

            _context.PoliticalParties.Update(politicalPartyToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return politicalParty;

            return null;
        }
    }
}
