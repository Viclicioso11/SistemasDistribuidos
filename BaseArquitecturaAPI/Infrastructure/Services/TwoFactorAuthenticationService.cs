using Application.Common.Interfaces;
using Application.UserActions.Dtos;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<TwoFactorAuthentication> CreateTwoFactorAuthentication(int userId)
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

            return tfa;

        }


        public async Task<TwoFactorAuthenticationDto> ValidateTwoFactorAuthentication(string otp, int tfaId, int userId)
        {

            var tfa = await _context.TwoFactorAuthentications.Where(t => (t.Id == tfaId && t.UserId == userId) && (t.Status == 1)).FirstOrDefaultAsync();

            // si no se encontró el registro
            if (tfa == null)
                return null;
               
            // si ya expiró actualizamos el estado
            if(DateTime.Now > tfa.ExpirationDate)
            {
                var expired = tfa;
                expired.Status = 3;

                _context.TwoFactorAuthentications.Update(expired);

                int updated = _context.SaveChanges();

                if (updated == 0)
                    return null;

                return new TwoFactorAuthenticationDto
                {
                    Attempts = 0,
                    Id = tfaId,
                    Message = "Token expirado",
                    UserId = userId,
                    Validated = false
                };
            }

            // si el otp es distinto al brindado
            if(!tfa.OneTimePassword.Equals(otp))
            {
                tfa.Attempts -= 1;

                // si ya los intentos son 0, actualizamos el estado a 4
                if (tfa.Attempts == 0)
                    tfa.Status = 4;

                _context.TwoFactorAuthentications.Update(tfa);

                int updated = _context.SaveChanges();

                if (updated == 0)
                    return null;

                return new TwoFactorAuthenticationDto
                {
                    Attempts = tfa.Attempts,
                    Id = tfaId,
                    Message = tfa.Attempts == 0 ? "Intentos permitidos alcanzados" : $"{tfa.Attempts} intentos restantes",
                    UserId = userId,
                    Validated = false
                };
            }
            // Si el otp es valido

            tfa.Status = 2;
            tfa.Attempts -= 1;

            _context.TwoFactorAuthentications.Update(tfa);

            int updatedValid = _context.SaveChanges();

            if (updatedValid == 0)
                return null;

            return new TwoFactorAuthenticationDto
            {
                Attempts = tfa.Attempts,
                Id = tfaId,
                Message = "Validación correcta",
                UserId = userId,
                Validated = true
            };

        }
    }
}
