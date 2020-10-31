using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.UserActions.Dtos;
using Application.UserActions.Querys;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GenericPager<UserDto>>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GenericPager<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _service.GetAllUser(request.FilterBy, request.ActualPage, request.RecordsByPage);

            return results;
            
        }
    }
}
