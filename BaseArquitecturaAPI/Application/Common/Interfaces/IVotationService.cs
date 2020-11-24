using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IVotationService
    {
        public Task<Votation> GetVotationById(int id);

        public Task<bool> CreateVotation(Votation votation);

        public Task<bool> UpdateVotation(Votation votation);

        public Task<bool> UpdateVotationStatus(bool status, int votationId);

        public Task<Votation> GetCurrentVotation();

        public Task<Votation> GetCurrentVotationByCityId(int cityId);
    }
}
