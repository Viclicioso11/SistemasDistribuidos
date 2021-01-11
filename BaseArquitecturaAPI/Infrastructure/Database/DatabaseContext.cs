using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Domain.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            if(optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .ApplyConfiguration(new VotationTypeConfigurationBuilder())
                .ApplyConfiguration(new VotationConfiguration())
                .ApplyConfiguration(new UserConfigurationBuilder())
                .ApplyConfiguration(new RolConfigurationBuilder())
                .ApplyConfiguration(new OptionConfigurationBuilder())
                .ApplyConfiguration(new RolOptionConfigurationBuilder())
                .ApplyConfiguration(new UserRolConfigurationBuilder())
                .ApplyConfiguration(new VoteConfigurationBuilder())
                .ApplyConfiguration(new CandidateConfigurationBuilder())
                .ApplyConfiguration(new PoliticalPartyConfigurationBuilder())
                .ApplyConfiguration(new UserAuditsConfigurationBuilder())
                .ApplyConfiguration(new VoteAuditConfigurationBuilder())
                .ApplyConfiguration(new CandidateAuditConfigurationBuilder())
                .ApplyConfiguration(new VoteAuditConfigurationBuilder())
                .ApplyConfiguration(new CityConfigurationBuilder())
                .ApplyConfiguration(new StateConfigurationBuilder())
                .ApplyConfiguration(new CountryConfigurationBuilder())
                .ApplyConfiguration(new VotationAuditConfiguration())
                .ApplyConfiguration(new VotationDetailsConfigurationBuilder())
                .ApplyConfiguration(new TwoFactorAuthenticationConfigurationBuilder());

        }


        public DbSet<Votation> Votations { get; set; }

        public DbSet<VotationType> VotationTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rol> Rols { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<UserRol> UserRols { get; set; }

        public DbSet<RolOption> RolOptions { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateAudit> CandidateAudits { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<PoliticalParty> PoliticalParties { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<VoteAudit> VoteAudits { get; set; }

        public DbSet<UserAudit> UserAudits { get; set; }

        public DbSet<TwoFactorAuthentication> TwoFactorAuthentications { get; set; }

        public DbSet<VotationDetail> VotationDetail { get; set; }
    }
}
