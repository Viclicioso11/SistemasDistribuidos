using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Pager;
using Application.VotationActions.Commands;
using Application.VotationActions.Dtos;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IVotationService
    {
        public Task<VotationDto> GetVotationById(int id);

        public Task<GenericPager<VotationDto>> GetAllVotation(string filterBy, int page, int recordsByPage);

        public Task<int> CreateVotation(Votation votation);

        public Task<bool> AddVotationCandidate(List<int> candidatesId, int votationId);

        public Task<bool> UpdateVotation(Votation votation);

        public Task<bool> UpdateVotationStatus(bool status, int votationId);

        public Task<Votation> GetCurrentVotation();

        public Task<Votation> GetCurrentVotationByCityId(int cityId);
    }
}
