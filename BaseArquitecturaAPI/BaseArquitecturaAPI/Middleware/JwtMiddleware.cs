using Application.Common.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            int? userId = 0;

            if (token != null)
            {
                var tokenHelper = new JwtHelper(_conf);

                userId = tokenHelper.ValidateJwtToken(token);

                // si no es valido se setea en 0 para validar en los endpoints
                if (userId == null)
                    userId = 0;
            }
                
            context.Items["UserId"] = userId;
            
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
