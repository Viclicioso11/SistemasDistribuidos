using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.VotationActions.Dtos;
using Application.VotationActions.Querys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VotationActions.Handlers
{
    public class GetAllVotationsQueryHandler: IRequestHandler<GetAllVotationsQuery, GenericPager<VotationDto>>
    {
        private readonly IVotationService _votationService;
        public GetAllVotationsQueryHandler(IVotationService votationService)
        {
            _votationService = votationService;
        }

        public async Task<GenericPager<VotationDto>> Handle(GetAllVotationsQuery request, CancellationToken cancellationToken)
        {
            var results = await _votationService.GetAllVotation(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;
        }
    }
}
