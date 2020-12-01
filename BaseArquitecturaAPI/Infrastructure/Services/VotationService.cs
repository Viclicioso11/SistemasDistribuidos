using Application.CandidateActions.Dtos;
using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.VotationActions.Commands;
using Application.VotationActions.Dtos;
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
    /// <summary>
    /// This class implement IVotationService Interface and is responsable of connecting to db or creating http requests
    /// </summary>
    public class VotationService : IVotationService
    {
        private readonly DatabaseContext _context;
        public VotationService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> AddVotationCandidate(List<int> candidatesId, int votationId)
        {
            foreach (var candidateId in candidatesId)
            {

                var candidate = await _context.Candidates.FindAsync(candidateId);

                if (candidate == null)
                    return false;

                _context.VotationDetail.Add(new VotationDetail { CandidateId = candidateId, VotationId = votationId });

            }

            var saved = _context.SaveChanges();

            if (saved == 0)
                return false;


            return true;
        }

        public async Task<int> CreateVotation(Votation votation)
        {
            votation.VotationStatus = true;
            _context.Add(votation);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return 0;

            return votation.Id;
        }

        public async Task<GenericPager<VotationDto>> GetAllVotation(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<VotationDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;


            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await (from v in _context.Votations
                                             join t in _context.VotationTypes
                                             on v.VotationTypeId equals t.Id
                                             join c in _context.Cities
                                             on v.CityId equals c.Id
                                             select new VotationDto
                                             {
                                                 Id = v.Id,
                                                 VotationDescription = v.VotationDescription,
                                                 VotationTypeId = t.Id,
                                                 VotationTypeName = t.VotationTypeName,
                                                 VotationEndDate = v.VotationEndDate,
                                                 VotationStartDate = v.VotationStartDate,
                                                 VotationStatus = v.VotationStatus,
                                                 CityId = c.Id,
                                                 CityName = c.CityName
                                             })
                                             .Skip((page - 1) * recordsByPage)
                                             .Take(recordsByPage)
                                             .ToListAsync();

                information.TotalRecords = _context.Votations.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {

                information.Results = await (from v in _context.Votations
                                             join t in _context.VotationTypes
                                             on v.VotationTypeId equals t.Id
                                             join c in _context.Cities
                                             on v.CityId equals c.Id
                                             where v.VotationDescription.Contains(filterBy)
                                             select new VotationDto
                                             {
                                                 Id = v.Id,
                                                 VotationDescription = v.VotationDescription,
                                                 VotationTypeId = t.Id,
                                                 VotationTypeName = t.VotationTypeName,
                                                 VotationEndDate = v.VotationEndDate,
                                                 VotationStartDate = v.VotationStartDate,
                                                 VotationStatus = v.VotationStatus,
                                                 CityId = c.Id,
                                                 CityName = c.CityName
                                             })
                                             .Skip((page - 1) * recordsByPage)
                                             .Take(recordsByPage)
                                             .ToListAsync();

                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }

            return information;
        }

        // para validar si hay una votación en curso
        public async Task<Votation> GetCurrentVotation()
        {
            var currentVotations = await _context.Votations.Where(v => v.VotationStatus == true).ToListAsync();

            foreach (var vot in currentVotations)
            {
                if (vot.VotationEndDate > DateTime.Now)
                    return vot;
            }

            return null;
        }

        // para validar si hay votaciones en alguna ciudad en curso
        public async Task<Votation> GetCurrentVotationByCityId(int cityId)
        {
            var votations = await _context.Votations.Where(v => v.CityId == cityId && v.VotationStatus == true).ToListAsync();

            foreach (var vot in votations)
            {
                if (vot.VotationEndDate > DateTime.Now)
                    return vot;
            }

            return null;
        }

        public async Task<VotationDto> GetVotationById(int id)
        {
            //another way
            var votation = await (from v in _context.Votations
                            join c in _context.Cities
                            on v.CityId equals c.Id
                            join t in _context.VotationTypes
                            on v.VotationTypeId equals t.Id
                            where v.Id == id
                            select new VotationDto
                            {
                                Id = v.Id,
                                VotationDescription = v.VotationDescription,
                                VotationTypeId = t.Id,
                                VotationTypeName = t.VotationTypeName,
                                VotationEndDate = v.VotationEndDate,
                                VotationStartDate = v.VotationStartDate,
                                VotationStatus = v.VotationStatus,
                                CityId = c.Id,
                                CityName = c.CityName
                            }).FirstOrDefaultAsync();

            if (votation == null)
                return null;

            votation.Candidates = (from vd in _context.VotationDetail
                                  join c in _context.Candidates
                                  on vd.CandidateId equals c.Id
                                  join p in _context.PoliticalParties
                                  on c.PoliticalPartyId equals p.Id
                                  where vd.VotationId == id
                                  select new CandidateDto
                                  {
                                      FirstName = c.FirstName,
                                      Surname = c.Surname,
                                      LastName = c.LastName,
                                      MiddleName = c.MiddleName,
                                      PoliticalPartyId = c.PoliticalPartyId,
                                      PoliticalPartyName = p.PoliticalPartyName,
                                      Id = c.Id,
                                  }).ToList();


            return votation;
        }

        public async Task<bool> UpdateVotation(Votation votation)
        {
            var votationToEdit = _context.Votations.Find(votation.Id);

            if (votationToEdit == null)
                return false;

            votationToEdit.VotationDescription = votation.VotationDescription;

            _context.Votations.Update(votationToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return true;

            return false;
        }

        public async Task<bool> UpdateVotationStatus(bool status, int votationId)
        {
            var votationToEdit = _context.Votations.Find(votationId);

            if (votationToEdit == null)
                return false;

            votationToEdit.VotationStatus = status;

            _context.Votations.Update(votationToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return true;

            return false;
        }
    }
}
