using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserActions.Dtos;
using Application.UserActions.Querys;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _service.GetUserById(request.Id);

            if (result == null)
                throw new NotFoundException("", request.Id);

            return _mapper.Map<UserDto>(result);
        }
    }
}
