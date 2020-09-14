﻿using Application.Common.Interfaces;
using AutoMapper.Configuration;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencyInjection (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITestService, TestService>();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("votationDb")));
            return services;

        }
    }
}
