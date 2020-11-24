using Application.Common.Interfaces;
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
    /// This class implement IVotationService Interface and is responsable of connecting to db or to http requests
    /// </summary>
    public class VotationService : IVotationService
    {
        private readonly DatabaseContext _context;
        public VotationService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVotation(Votation votation)
        {
            _context.Add(votation);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        // para validar si hay una votación en curso
        public async Task<Votation> GetCurrentVotation()
        {
            var currentVotation = await _context.Votations.Where(v => v.VotationEndDate < DateTime.Now).FirstOrDefaultAsync();

            return currentVotation;
        }

        // para validar si hay votaciones en alguna ciudad en curso
        public async Task<Votation> GetCurrentVotationByCityId(int cityId)
        {
            var votation = await _context.Votations.Where(v => v.CityId == cityId && v.VotationEndDate < DateTime.Now).FirstOrDefaultAsync();

            return votation;
        }

        public async Task<Votation> GetVotationById(int id)
        {
            //another way
            var votation = (from v in _context.Votations
                           join c in _context.Cities
                           on v.CityId equals c.Id
                           join t in _context.VotationTypes
                           on v.VotationTypeId equals t.Id
                           where v.Id == id
                           select new Votation
                           {
                               Id = v.Id,
                               VotationDescription = v.VotationDescription,
                               VotationType = t,
                               City = c,
                               VotationEndDate = v.VotationEndDate,
                               VotationStartDate = v.VotationStartDate,
                               VotationStatus = v.VotationStatus
                           }).FirstOrDefault();

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
