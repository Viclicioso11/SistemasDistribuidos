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
    public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, AuthenticationDto>
    {
        private readonly IUserService _service;
        private readonly ITwoFactorAuthenticationService _tfaService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AuthenticationCommandHandler(IUserService service, IMapper mapper, ITwoFactorAuthenticationService tfaService, IEmailService emailService)
        {
            _service = service;
            _mapper = mapper;
            _tfaService = tfaService;
            _emailService = emailService;
        }
        public async Task<AuthenticationDto> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {

            var userId = await _service.AuthenticateUser(request.Email, request.Password);

            if (userId == 0)
                return null;

            //si las credenciales son correctas, se envia el correo y se guarda en tfa

            var tfa = await _tfaService.CreateTwoFactorAuthentication(userId);

            if (tfa == null)
                throw new ErrorException("01", "Error tratando de guardar TFA");

            //enviamos correo
            var sended = await _emailService.SendEmail(request.Email, "Correo de mensaje de confirmación", tfa.OneTimePassword);

            if(!sended)
                throw new ErrorException("01", "Error intentando enviar el correo");

            return new AuthenticationDto { Id = tfa.Id, UserId = tfa.UserId};
        }
    }
}
