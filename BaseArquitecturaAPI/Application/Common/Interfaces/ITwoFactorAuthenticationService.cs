using Application.UserActions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ITwoFactorAuthenticationService
    {
        Task<AuthenticationDto> CreateTwoFactorAuthentication(int userId);
    }
}
