using Application.Common.Interfaces;
using AutoMapper.Configuration;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencyInjection (this IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(""));
            return services;

        }
    }
}
