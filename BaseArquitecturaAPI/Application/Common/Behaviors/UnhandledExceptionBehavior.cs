using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class UnhandledExceptionBehavior <TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return next();
            }
            catch (Exception e)
            {

                logger.Log(NLog.LogLevel.Error, e, "Message:");
                throw e;
            }

        }
    }
}
