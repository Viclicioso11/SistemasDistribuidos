using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.UserActions.Commands;
using Application.UserActions.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserActions.Handlers
{
    public class AnwerTwoFactorAuthenticationCommandHandler : IRequestHandler<AnswerTwoFactorAuthenticatonCommand, TwoFactorAuthenticationDto>
    {
        private readonly ITwoFactorAuthenticationService _tfaService;
        private readonly IUserService _userService;
        private readonly IUserRolService _userRolService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _conf;
        public AnwerTwoFactorAuthenticationCommandHandler(IMapper mapper, ITwoFactorAuthenticationService tfaService, IConfiguration configuration, IUserService userService, IUserRolService userRolService)
        {
            _mapper = mapper;
            _tfaService = tfaService;
            _userService = userService;
            _conf = configuration;
            _userRolService = userRolService;
        }

        public async Task<TwoFactorAuthenticationDto> Handle(AnswerTwoFactorAuthenticatonCommand request, CancellationToken cancellationToken)
        {
            var tfaDto = await _tfaService.ValidateTwoFactorAuthentication(request.OneTimePassword, request.AuthenticationId, request.UserId);

            if (tfaDto == null)
                throw new NotFoundException("No se ha encontrado", request.AuthenticationId);

            if (!tfaDto.Validated)
                return tfaDto;

            var user = await _userService.GetUserById(tfaDto.UserId);

            var tokenHelper = new JwtHelper(_conf);

            var userRol = await _userRolService.GetRolByUserId(user.Id);

            tfaDto.Token = tokenHelper.GenerateJwtToken(user,  new Rol { RolName = userRol.RolName });

            return tfaDto;

        }
        
    }
}
