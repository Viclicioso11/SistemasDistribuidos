using Application.CandidateActions.Commands;
using Application.CandidateActions.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.OptionActions.Commands;
using Application.OptionActions.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptionActions.Handlers
{
    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, OptionDto>
    {
        private readonly IOptionService _service;
        private readonly IMapper _mapper;
        public CreateOptionCommandHandler(IOptionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<OptionDto> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateOption(request.Option);

            if (!result)
                throw new ErrorException("01", "Error tratando de crear Opción");

            return _mapper.Map<OptionDto>(request.Option);
        }
    
    }
}
