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

        public async Task<Votation> GetVotationById(int id)
        {
            //another way
            var votation = (from v in _context.Votations
                           join c in _context.Cities
                           on v.CityId equals c.CityId
                           join t in _context.VotationTypes
                           on v.VotationTypeId equals t.VotationTypeId
                           where v.VotationId == id
                           select new Votation
                           {
                               VotationId = v.VotationId,
                               VotationDescription = v.VotationDescription,
                               VotationType = t,
                               City = c,
                               VotationEndDate = v.VotationEndDate,
                               VotationStartDate = v.VotationStartDate,
                               VotationStatus = v.VotationStatus
                           }).FirstOrDefault();

            return votation;
        }
    }
}
