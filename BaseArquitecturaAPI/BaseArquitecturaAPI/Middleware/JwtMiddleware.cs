using Application.Common.Exceptions;
using Application.Common.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _conf;

        public JwtMiddleware(RequestDelegate next, IConfiguration conf)
        {
            _next = next;
            _conf = conf;
        }

        public async Task Invoke(HttpContext context)
        {
           //just testing now
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
                throw new UnauthorizedException("Falta token");

            var tokenHelper = new JwtHelper(_conf);

            var result = tokenHelper.ValidateJwtToken(token);

            if(result == null)
                throw new UnauthorizedException("Token no válido");

            context.Items["UserId"] = result;
            
            await _next(context);
        }

        

    }

    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();

            return app;
        }
    }
}
