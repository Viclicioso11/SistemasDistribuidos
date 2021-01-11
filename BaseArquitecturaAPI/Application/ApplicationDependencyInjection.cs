using Application.Common.Behaviors;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationDependencyInjection 
    { 
        public static IServiceCollection AddApplicationDependencyInjection (this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
        
    }
}
