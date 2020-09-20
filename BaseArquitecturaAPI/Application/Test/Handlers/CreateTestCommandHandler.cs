using Application.Common.Interfaces;
using Application.Test.Commands;
using Application.Test.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Test.Handlers
{
    /*public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, TestDto>
    {
        private readonly IMapper _mapper;
        private readonly ITestService _service;
        public CreateTestCommandHandler(IMapper mapper, ITestService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<TestDto> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            
             * consume services here
            var testInformation = await _service.GetTestById(request.Id);
           
            
            //return new TestDto { };
            //return _mapper.Map<TestDto>(testInformation);
        }
    }
*/
}
