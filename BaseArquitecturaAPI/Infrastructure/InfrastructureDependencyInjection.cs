using Application.Common.Interfaces;
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
using Microsoft.AspNetCore.Http;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencyInjection (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IVotationService, VotationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<ITwoFactorAuthenticationService, TwoFactorAuthenticationService>();
            services.AddTransient<IPoliticalPartyService, PoliticalPartyService>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IOptionService, OptionService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IRolOptionService, RolOptionService>();
            services.AddTransient<IUserRolService, UserRolService>();
            services.AddTransient<IVoteService, VoteService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("votationDb")));
            return services;

        }
    }
}
