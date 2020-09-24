using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IVotationService
    {
        public Task<entity.Votation> GetVotationById(int id);
    }
}
