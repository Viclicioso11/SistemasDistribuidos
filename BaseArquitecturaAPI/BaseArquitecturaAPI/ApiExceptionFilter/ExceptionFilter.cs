using Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.ApiExceptionFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            if(context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }

            if (context.Exception is AlreadyExistsException)
            {
                statusCode = HttpStatusCode.Conflict;
            }


            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;

            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
            });

        }
    }
}
