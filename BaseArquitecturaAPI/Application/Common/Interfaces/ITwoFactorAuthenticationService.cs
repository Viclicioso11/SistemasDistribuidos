using Application.UserActions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ITwoFactorAuthenticationService
    {
        Task<TwoFactorAuthentication> CreateTwoFactorAuthentication(int userId);

        Task<TwoFactorAuthenticationDto> ValidateTwoFactorAuthentication(string otp, int tfaId, int userId);
    }
}
