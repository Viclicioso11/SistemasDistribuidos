using Application.Common.Pager;
using Application.PoliticalPartyActions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPoliticalPartyService
    {
        public Task<PoliticalPartyDto> GetPoliticalPartyById(int politicalPatyId);

        public Task<PoliticalParty> UpdatePoliticalParty(PoliticalParty politicalPaty);

        public Task<bool> CreatePoliticalParty(PoliticalParty politicalPaty);

        public Task<GenericPager<PoliticalPartyDto>> GetAllPoliticalParties(string filterBy, int page, int recordsByPage);
    }
}
