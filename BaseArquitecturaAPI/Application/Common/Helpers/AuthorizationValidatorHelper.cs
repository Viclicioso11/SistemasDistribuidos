using Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Helpers
{
    public class AuthorizationValidatorHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationValidatorHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //returns the user Id if is valid 
        public int ValidateUserAuthorization()
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"] == null ? "0" : _httpContextAccessor.HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            return int.Parse(userId);
        }
    }
}
