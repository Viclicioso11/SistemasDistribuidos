using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserActions.Commands;
using Application.UserActions.Dtos;
using AutoMapper;
using MediatR;
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
        private readonly IMapper _mapper;
        public AnwerTwoFactorAuthenticationCommandHandler(IMapper mapper, ITwoFactorAuthenticationService tfaService)
        {
            _mapper = mapper;
            _tfaService = tfaService;
        }

        public async Task<TwoFactorAuthenticationDto> Handle(AnswerTwoFactorAuthenticatonCommand request, CancellationToken cancellationToken)
        {
            var tfaDto = await _tfaService.ValidateTwoFactorAuthentication(request.OneTimePassword, request.AuthenticationId, request.UserId);

            if (tfaDto == null)
                throw new NotFoundException("No se ha encontrado", tfaDto.TwoFactorAuthenticationId);

            return tfaDto;

        }
        
    }
}
