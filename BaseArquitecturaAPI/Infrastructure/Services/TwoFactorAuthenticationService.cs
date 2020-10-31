using Application.Common.Interfaces;
using Application.UserActions.Dtos;
using Domain.Entities;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TwoFactorAuthenticationService : ITwoFactorAuthenticationService
    {
        private readonly DatabaseContext _context;
        public TwoFactorAuthenticationService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<AuthenticationDto> CreateTwoFactorAuthentication(int userId)
        {
            var otp = new Random().Next(100000, 999999);

            var tfa = new TwoFactorAuthentication
            {
                Attempts = 3,
                OneTimePassword = otp.ToString(),
                UserId = userId,
                Status = 1, // 1  iniciado, 2 aprobado, 3 expirado, 4 maximo de intentos
                ExpirationDate = DateTime.Now.AddMinutes(3),

            };

            _context.Add(tfa);

            var saved = await _context.SaveChangesAsync();

            if (saved == 0)
                return null;

            return new AuthenticationDto
            {
                AuthenticationId = tfa.TwoFactorAuthenticationId,
                OneTimePassword = otp.ToString()
            };



        }
    }
}
