using Application.Common.Interfaces;
using Application.Test.Dtos;
using Application.Test.Querys;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Test.Handlers
{
    /// <summary>
    /// This class handle the request after getting into the command or query class
    /// </summary>
    public class GetTestByIdQueryHandler : IRequestHandler<GetTestByIdQuery, TestDto>
    {
        private readonly IMapper _mapper;
        private readonly ITestService _service;
        public GetTestByIdQueryHandler(IMapper mapper, ITestService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<TestDto> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            var testInformation = await _service.GetTestById(request.TestId);

            return _mapper.Map<TestDto>(testInformation);
        }
    }
}
